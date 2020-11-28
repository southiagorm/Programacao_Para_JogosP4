using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Transform pointA, pointB, pointAux;
    
    void Start()
    {
        transform.position = pointA.position;
        pointAux = pointB;
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointAux.position, speed * Time.deltaTime);

        if(transform.position.y <= pointB.position.y)
        {
            pointAux = pointA;
        }else if(transform.position.y >= pointA.position.y)
        {
            pointAux = pointB;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Colisao");
            other.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}

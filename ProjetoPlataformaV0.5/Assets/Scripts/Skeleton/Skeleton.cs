using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField]
    public float speed;

    public bool lookRight = true;
    public bool attack = false;

    [SerializeField]
    private Transform pointA, pointB, pointAux;

    private Animator anim;

    void Start()
    {
        transform.position = pointB.position;
        pointAux = pointA;

        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        //print(Vector2.Distance(transform.position, Player.instance.transform.position));
        if(Vector2.Distance(transform.position,Player.instance.transform.position) < 1)
        {
            if((transform.position.x < Player.instance.transform.position.x) && !lookRight)
            {
                Flip();
            }

            StartCoroutine(CorotinaAttack());
        }

        if (!attack)
        {

            if (transform.position.x <= pointA.position.x)
            {
                Flip();
                pointAux = pointB;
            }

            if (transform.position.x >= pointB.position.x)
            {
                Flip();
                pointAux = pointA;
            }

            transform.position = Vector2.MoveTowards(transform.position, pointAux.position, speed * Time.deltaTime);
        }
    }

    public void Flip()
    {
        lookRight = !lookRight;
        float tempScaleX = transform.localScale.x * -1;
        transform.localScale = new Vector3(tempScaleX, transform.localScale.y, transform.localScale.z);
    }

    IEnumerator CorotinaAttack()
    {
        attack = true;
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(0.8f);
        attack = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float _h, _v;
    private Rigidbody2D rb2dBody;

    [SerializeField]
    private int pontuacao;
    
    void Start()
    {
        rb2dBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb2dBody.MovePosition(rb2dBody.position + (new Vector2(_h, _v)*speed*Time.deltaTime));    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moeda"))
        {
            pontuacao += 1;
            Destroy(other.gameObject);
        }  
    }
}

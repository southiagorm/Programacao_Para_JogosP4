using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    
    private Rigidbody2D rb2d;
    private Animator anim;
    private float h;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("run", Mathf.Abs(h));
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(h * speed * Time.deltaTime, rb2d.velocity.y);
    }
}

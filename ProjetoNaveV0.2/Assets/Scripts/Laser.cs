using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;
    private Rigidbody2D _rb2dBody;
    // Start is called before the first frame update
    void Start()
    {
        _rb2dBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //_rb2dBody.velocity = new Vector2(0,speed*Time.deltaTime);
        _rb2dBody.MovePosition(_rb2dBody.position + new Vector2(0, speed * Time.deltaTime));
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);    
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        print("acabou de colidir");
    }

    void OnCollisionStay2D(Collision2D other)
    {
        print("continua colidindo");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("enter trigger");
        if(other.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        print("stay trigger");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        print("exit trigger");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float speed = 300;
    private float _h, _v;

    public GameObject prefabBala;

    private Rigidbody2D _rb2dBody;

    public float timeRate = 0;
    public float maxTime = 1;

    void Start()
    {
        _rb2dBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        timeRate += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (timeRate >= maxTime)
            {
                Instantiate(prefabBala, transform.position + new Vector3(0, 1, 0), transform.rotation);
                timeRate = 0;
            }
        }

        if(transform.position.x >= 10.0f)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
        if(transform.position.x <= -10.0f)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
        if(transform.position.y >= 2.2f)
        {
            transform.position = new Vector3(transform.position.x, 2.2f, transform.position.z);
        }
        if (transform.position.y <= -4.4f)
        {
            transform.position = new Vector3(transform.position.x, -4.4f, transform.position.z);
        }
    }

    void FixedUpdate()
    {
        //_rb2dBody.velocity = new Vector2(_h * speed * Time.deltaTime, _v * speed * Time.deltaTime);
        _rb2dBody.MovePosition(_rb2dBody.position + (new Vector2(_h,_v) * speed * Time.deltaTime));
    }

    void OnCollisionExit2D(Collision2D other)
    {
        print("Deixou de colidir");
    }
}

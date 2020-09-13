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

    void Start()
    {
        _rb2dBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(prefabBala, transform.position + new Vector3(0,1,0), transform.rotation);
        }
    }

    void FixedUpdate()
    {
        _rb2dBody.velocity = new Vector2(_h * speed * Time.deltaTime, _v * speed * Time.deltaTime);
    }
}

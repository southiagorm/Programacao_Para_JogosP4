using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float speed = 0.01f;
    private float _h, _v;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //transform.Translate(0,0.01f,0);
        //transform.Rotate(0, 0, 1);

        /*if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(0,speed,0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0,-speed,0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed, 0, 0);
        }*/

        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        transform.Translate(_h*speed,_v*speed, 0);
    }
}

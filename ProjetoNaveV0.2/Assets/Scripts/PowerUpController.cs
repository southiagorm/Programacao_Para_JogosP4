using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUp
{
    POWER,
    VELOCITY,
    SHIELD
}

public class PowerUpController : MonoBehaviour
{
    public PowerUp powerUp;
    public float speed;

    private Rigidbody2D _rb2dBody;
    
    void Start()
    {
        _rb2dBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb2dBody.MovePosition(_rb2dBody.position + (new Vector2(0,speed*Time.deltaTime)));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            switch (powerUp)
            {
                case PowerUp.POWER:
                    other.gameObject.GetComponent<Nave>().ActiveTripleShoot();
                    break;
                case PowerUp.VELOCITY:
                    other.gameObject.GetComponent<Nave>().ActiveVelocity();
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlack : MonoBehaviour
{
    public float speed;
    public Vector2 direction;

    private Rigidbody2D _rb2dBody;

    [SerializeField]
    private GameObject prefabExplosion;
    // Start is called before the first frame update
    void Start()
    {
        _rb2dBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 0)
        {
            direction = new Vector2(1,-1);
        }
    }

    void FixedUpdate()
    {
        _rb2dBody.MovePosition(_rb2dBody.position + direction * speed * Time.deltaTime);    
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Laser"))
        {
            Destroy(this.gameObject);
            Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        }
    }
}

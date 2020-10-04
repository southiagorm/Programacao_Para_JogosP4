using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRed : MonoBehaviour
{
    public float speed;
    public Vector2 direction;

    private Rigidbody2D _rb2dBody;

    [SerializeField]
    private GameObject prefabExplosion;
    [SerializeField]
    private GameObject prefabTiro;

    private float timeRate = 0;
    private float maxTime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        _rb2dBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timeRate += Time.deltaTime;

        if(timeRate >= maxTime)
        {
            Instantiate(prefabTiro, transform.position - new Vector3(0,1f,0), Quaternion.identity);
            timeRate = 0;
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

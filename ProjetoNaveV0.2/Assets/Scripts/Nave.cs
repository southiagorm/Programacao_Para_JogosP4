using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Nave : MonoBehaviour
{
    public float speed;
    private float _h, _v;

    public GameObject prefabBala;

    private Rigidbody2D _rb2dBody;

    public float timeRate = 0;
    public float maxTime = 1;

    public bool canTripleShoot = false;

    void Start()
    {
        _rb2dBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        Shoot();

        ScreenBounds();
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

    private void OneShoot()
    {
        Instantiate(prefabBala, transform.position + new Vector3(0, 1, 0), transform.rotation);
    }

    private void TripleShoot()
    {
        Instantiate(prefabBala, transform.position + new Vector3(0, 1, 0), transform.rotation);
        Instantiate(prefabBala, transform.position + new Vector3(0.5f, 0.5f, 0), transform.rotation);
        Instantiate(prefabBala, transform.position + new Vector3(-0.5f, 0.5f, 0), transform.rotation);
    }

    public void Shoot()
    {
        timeRate += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (timeRate >= maxTime)
            {
                if (!canTripleShoot){
                    OneShoot();
                }
                else{
                    TripleShoot();
                }
                timeRate = 0;
            }
        }
    }

    public void ScreenBounds()
    {
        if (transform.position.x >= 10.0f)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -10.0f)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
        if (transform.position.y >= 2.2f)
        {
            transform.position = new Vector3(transform.position.x, 2.2f, transform.position.z);
        }
        if (transform.position.y <= -4.4f)
        {
            transform.position = new Vector3(transform.position.x, -4.4f, transform.position.z);
        }
    }

    public void ActiveTripleShoot()
    {
        StartCoroutine(CoroutineTrippleShoot());
    }

    public void ActiveVelocity()
    {
        StartCoroutine(CoroutineVelocity());
    }


    IEnumerator CoroutineTrippleShoot()
    {
        canTripleShoot = true;
        yield return new WaitForSeconds(5);
        canTripleShoot = false;
    }

    IEnumerator CoroutineVelocity()
    {
        speed = 15;
        yield return new WaitForSeconds(5);
        speed = 8;
    }
}

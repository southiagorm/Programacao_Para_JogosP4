using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;

    private bool lookRight = true;

    [SerializeField]
    private bool isGround;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;

    private Rigidbody2D rb2d;
    private Animator anim;
    private float h;

    private bool isAttack = false;

    void Awake()
    {
        instance = this;    
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer);

        //print(isGround);
        if (isAttack)
        {
            h = 0;
        }else{
            h = Input.GetAxisRaw("Horizontal");
        }

        if(h > 0 && !lookRight)
        {
            Flip();
        }

        if(h < 0 && lookRight)
        {
            Flip();
        }

        Attack();

        Jump();

        anim.SetFloat("run", Mathf.Abs(h));
        anim.SetFloat("velocityY",rb2d.velocity.y);
        anim.SetBool("isGround", isGround);

        //print(rb2d.velocity.x);
    }

    void FixedUpdate()
    {
        if (!isAttack)
        {
            rb2d.velocity = new Vector2(h * speed * Time.deltaTime, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1") && isGround)
        {
            anim.SetTrigger("attack");
            StartCoroutine(CoroutineEnableAttack());
        }
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }

    public void Flip()
    {
        lookRight = !lookRight;
        float tempScaleX = transform.localScale.x * -1;
        transform.localScale = new Vector3(tempScaleX, transform.localScale.y, transform.localScale.z);
    }


    IEnumerator CoroutineEnableAttack()
    {
        isAttack = true;
        yield return new WaitForSeconds(0.72f);
        isAttack = false;
    }
}

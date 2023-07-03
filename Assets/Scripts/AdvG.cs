using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvG : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float speed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    private float Xmin = -8.297f;
    /*private float Ymin = -6.14f;
    private float Ymax = -2.7f;
    private float Ymax2 = 4.247f;*/
    public GameObject LvLCScreen;
    public GameObject GameOverScreen;
    public GameObject PauseButton;

    void Awake()
    {
        transform.position = new Vector2(-8.297f, -2.625f);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        speed = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump") && rb.velocity.y == 0)
        {
            rb.AddForce(Vector2.up * 600f);
        }
        
        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (rb.velocity.y > 0)
        {
            anim.SetBool("isJumping", true);
        }

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }

        Boundary();
    }

    void Boundary()
    {
        if (transform.position.x < Xmin)
        {
            transform.position = new Vector2(Xmin, transform.position.y);
        }
        /*else if (transform.position.y < Ymin)
        {
            transform.position = new Vector2(Xmin, Ymax);
        }
        else if (transform.position.y > Ymax2)
        {
            transform.position = new Vector2(transform.position.x, Ymax2);
        }*/
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void LateUpdate()
    {
        if (dirX > 0)
        {
            facingRight = true;
        }
        else if (dirX < 0)
        {
            facingRight = false;
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0) ) )
        {
            localScale.x *= -1; 
        }

        transform.localScale = localScale;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LvLC")
        {
            LvLCScreen.SetActive(true);
            PauseButton.SetActive(false);
            Time.timeScale = 0;
        }
        else if (collision.gameObject.tag == "Death")
        {
            GameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
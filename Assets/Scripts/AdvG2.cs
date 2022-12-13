using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvG2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float speed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    private float Xmin = -8f;
    private float Xmax = 7.9f;
    public GameObject GameOverScreen;
    [SerializeField]
    private GameOverLvL2 gameOverLvL2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal") * speed;

        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
        {
            anim.SetBool("isRunning2", true);
        }
        else
        {
            anim.SetBool("isRunning2", false);
        }

        Boundary();
    }

    void Boundary()
    {
        if (transform.position.x < Xmin)
        {
            transform.position = new Vector2(Xmin, transform.position.y);
        }
        else if (transform.position.x > Xmax)
        {
            transform.position = new Vector2(Xmax, transform.position.y);
        }
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

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Spike")
        {
            GameOverScreen.SetActive(true);
            gameOverLvL2.SetGameOver();
            Time.timeScale = 0;
        }
    }
}
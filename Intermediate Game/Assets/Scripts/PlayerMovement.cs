using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    public float jumpingPower = 18f;
    private bool isFacingRight = true;
    private float centerPosition = 0;
    public float timeRemaining = 0;
    public float timeRemainingTwo = 0;
    public float timeRemainingThree = 0;
    public bool super = false;
    public bool walls = false;
    public bool control = false;
    public bool menuUp = false;



    public SpriteRenderer spriteRenderer;
    public Sprite bootSprite;

    public SpriteRenderer spriteRenderer2;
    public Sprite wallSprite;

    public SpriteRenderer spriteRenderer3;
    public Sprite controlSprite;

    public UnityEvent OnPressE;
    public event EventHandler OnPressF;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private BoxCollider2D balls;
    [SerializeField] private GameObject boot;
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject air;
    [SerializeField] private GameObject menu;
    [SerializeField] private BoxCollider2D endLine;
    [SerializeField] private GameObject dead;





    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.Escape) && menuUp == false)
        {
            menuUp = true;

        }else if(Input.GetKeyUp(KeyCode.Escape) && menuUp == true)
        {
            menuUp = false;
        }

        if(menuUp == false)
        {
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            menu.SetActive(false);
            if (Input.GetButtonDown("Vertical") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            if (Input.GetButtonUp("Vertical") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }

            Flip();

            MoveCamera();




            if (Input.GetKeyDown(KeyCode.E))
            {
                OnPressE.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                OnPressF.Invoke(this, EventArgs.Empty);
            }



            //super jump
            if (timeRemaining > 0)
            {
                jumpingPower = 25f;
                spriteRenderer.sprite = bootSprite;
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                jumpingPower = 18;
                spriteRenderer.sprite = null;
                boot.SetActive(true);
                super = false;
            }



            //wall jump
            if (timeRemainingTwo > 0)
            {
                timeRemainingTwo -= Time.deltaTime;
            }
            else
            {
                wall.SetActive(true);
                walls = false;
                spriteRenderer2.sprite = null;
            }



            //air control
            if (timeRemainingThree > 0)
            {
                horizontal = Input.GetAxisRaw("Horizontal");
                timeRemainingThree -= Time.deltaTime;
            }
            else
            {
                if (IsGrounded())
                {
                    horizontal = Input.GetAxisRaw("Horizontal");
                }
                air.SetActive(true);
                control = false;
                spriteRenderer3.sprite = null;
            }

        }
        else if(menuUp == true)
        {
            menu.SetActive(true);
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            MoveCamera();
        }

       

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(balls.bounds.center, balls.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void MoveCamera()
    {
        if(rb.transform.position.y > (centerPosition + 4.5f))
        {
            centerPosition = centerPosition + 8f;

            Camera.main.transform.position = new Vector3(0, centerPosition, -10);

        }

        if(rb.transform.position.y < (centerPosition - 4.5f))
        {
            centerPosition = centerPosition - 8f;

            Camera.main.transform.position = new Vector3(0, centerPosition, -10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SuperJump"))
        {
            if (walls == false && control == false)
            {
                boot.SetActive(false);
                super = true;
                spriteRenderer.sprite = bootSprite;
                timeRemaining = 10;
            }
        }

        if (collision.gameObject.CompareTag("WallClimb"))
        {
            if (super == false && control == false)
            {
                walls = true;
                wall.SetActive(false);
                spriteRenderer2.sprite = wallSprite;
                timeRemainingTwo = 15;
            }
        }

        if (collision.gameObject.CompareTag("AirControl"))
        {
            if (super == false && walls == false)
            {
                control = true;
                air.SetActive(false);
                spriteRenderer3.sprite = controlSprite;
                timeRemainingThree = 12;
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            dead.SetActive(true);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class EnemyScript : MonoBehaviour

{
    public float moveSpeed = -1f;
    private Rigidbody2D myBody;
    public bool menuUp;

    [SerializeField] private GameObject menu;
    [SerializeField] private Rigidbody2D rb;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && menuUp == false)
        {
            menuUp = true;

        }
        else if (Input.GetKeyUp(KeyCode.Escape) && menuUp == true)
        {
            menuUp = false;
        }

        if(menuUp == false)
        {
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        }
        else if(menuUp == true)
        {
            rb.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftCollider"))
        {
            moveSpeed = 1f;
        }

        if (collision.gameObject.CompareTag("RightCollider"))
        {
            moveSpeed = -1f;
        }
    }
}

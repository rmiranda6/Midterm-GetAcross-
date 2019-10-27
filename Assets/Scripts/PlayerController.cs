using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float xRange = 24;
    [SerializeField] float speed  = 10;
    //[SerializeField] GameObject projectilePrefab;
    [SerializeField] bool gameOver;
    [SerializeField] int health = 3;

    private Transform target;
    public bool carrying = false;
    public Transform theDest;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("object").GetComponent<Transform>();
        health = 3;
        gameOver = false;
    }
    void FixedUpdate()
    {
        playerMovement();
        pickUp();
        if (health == 0)
        {
            Debug.Log("Game Over");
            gameOver = true;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            //if(health == 0)
            //{
            //    Debug.Log("Game Over");
            //    gameOver = true;
            //    Destroy(gameObject);
            //}
        }
        if(collision.gameObject.CompareTag("object"))
        {
            pickUp();
        }
    }

    void playerMovement()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        //else if (transform.position.x > xRange)
        //{
        //    transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        //}
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(0, 0, horizontalInput * speed * Time.deltaTime);

        transform.Translate(-verticalInput * speed * Time.deltaTime, 0, 0);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        //}
    }

    void pickUp()
    {
        if (carrying == false && Vector3.Distance(transform.position, target.position) < 1)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().useGravity = false;
                GetComponent<Rigidbody>().freezeRotation = true;
                this.transform.position = theDest.position;
                this.transform.parent = GameObject.Find("Destination").transform;
                carrying = true;
            }
        }
        else if (carrying == true)// Drop
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.transform.parent = null;
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<BoxCollider>().enabled = true;
                GetComponent<Rigidbody>().freezeRotation = false;
                carrying = false;
            }
        }
    }
}

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

    void Start()
    {
        health = 3;
    }
    void FixedUpdate()
    {
        playerMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health--;
            if(health == 0)
            {
                Debug.Log("Game Over");
                gameOver = true;
                Destroy(gameObject);
            }
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
}

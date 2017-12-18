using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWaveController : MonoBehaviour {

    Rigidbody2D rb;
    float speed = 2, xSpeed;
    int difficulty = 1;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        setSpeed();
        MoveBall();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void MoveBall()
    {
        if (!gameManager.instance.gameOver)
        {
            rb.velocity = new Vector2(xSpeed, -speed);
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "BelowBar")
        {
            LifeManager.instance.decrementLife();
        }
        else if (col.gameObject.tag == "wall")
        {
            xSpeed = -xSpeed;
            MoveBall();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BelowBar" && !gameManager.instance.gameOver)
        {

            Destroy(gameObject);
            //  gameManager.instance.GameOver();
            LifeManager.instance.decrementLife();
        }

        else if (col.gameObject.tag == "wall")
        {
            xSpeed = -xSpeed;
            MoveBall();
        }
    }
    void setSpeed()
    {
        difficulty = DifficultyManager.instance.difficulty;
        if (difficulty < 3)
        {
            speed = 3 + Random.Range(0,1) ;
            xSpeed = 0;
        }
        else if (difficulty < 5)
        {
           
                xSpeed = 0;
          
            speed = 3 + Random.Range(0,1);
        }
        else 
        {
            int x = Random.Range(0, 5);
            if (x > 3)
            {
                xSpeed = Random.Range(-2, 2);
            }
            speed = 3 + Random.Range(0,2);
        }
    }
}

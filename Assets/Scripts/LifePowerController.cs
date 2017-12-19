using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePowerController : MonoBehaviour {

    Rigidbody2D rb;
    float speed = 5;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveBall();

    }
    
    void MoveBall()
    {
        if (!gameManager.instance.gameOver)
        {
            rb.velocity = new Vector2(0, -speed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BelowBar" && !gameManager.instance.gameOver)
        {
            Destroy(gameObject);
        }
    }

}

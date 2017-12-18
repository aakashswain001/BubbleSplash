﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyController : MonoBehaviour {


    Rigidbody2D rb;
    float speed = 2;
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
            rb.velocity = new Vector2(0, -speed);
        }
    }

    void setSpeed()
    {
        difficulty = DifficultyManager.instance.difficulty;
        if (difficulty == 1)
        {
            speed = Random.Range(3, 4);
        }
        else if (difficulty <= 3)
        {
            speed = Random.Range(4, 5);
        }
        else
        {
            speed = 3 + Random.Range(2, 5);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BelowBar" && !gameManager.instance.gameOver)
        {
            Destroy(gameObject);
        }
    }
    public void setHighSpeed()
    {
        speed = 4;
        MoveBall();
    }
}
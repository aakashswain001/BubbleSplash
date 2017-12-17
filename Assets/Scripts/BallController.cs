using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallController : MonoBehaviour {
    Rigidbody2D rb;
    float speed=2;
    int difficulty = 1;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        setSpeed();
        MoveBall();
        
    }

    // Update is called once per frame
    void Update () {
	    
	}
    void MoveBall()
    {
        if (!gameManager.instance.gameOver) {
            rb.velocity = new Vector2(0, -speed);
            }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "BelowBar")
        {
            //  gameManager.instance.GameOver();
            LifeManager.instance.decrementLife();
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
}
    void setSpeed() {
        difficulty = DifficultyManager.instance.difficulty;
        if (difficulty == 1)
        {
            speed = Random.Range(2, 3);
        }
        else if (difficulty <= 3)
        {
            speed = Random.Range(3, 4);
        }
        else {
            speed = 3 + Random.Range(1, 4);
        }
    }
}

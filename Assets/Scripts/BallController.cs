using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallController : MonoBehaviour {
    Rigidbody2D rb;
    float speed=2;
    public bool gameOver;
	// Use this for initialization
	void Start () {
        gameOver = false;
        rb = GetComponent<Rigidbody2D>();

        MoveBall();
    }

    // Update is called once per frame
    void Update () {
	
	}
    void MoveBall()
    {
        rb.velocity = new Vector2(0, -speed);
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "BelowBar")
        {
            gameOver = true;
            gameManager.instance.GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BelowBar" && !gameOver)
        {
            Destroy(gameObject);
            gameOver = true;
            gameManager.instance.GameOver();
            
			
    }
}
}

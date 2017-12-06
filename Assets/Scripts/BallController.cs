using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallController : MonoBehaviour {
    Rigidbody2D rb;
    float speed=2;
	bool isout=false; 
	// Use this for initialization
	void Start () {
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BelowBar")
        {
            Destroy(gameObject);
			isout = true;

			if (isout == true) 
			{
				SceneManager.LoadScene ("bubble");
				
			        }
    }
}
}

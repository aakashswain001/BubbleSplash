using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTouch : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            BoxCollider2D box = gameObject.AddComponent<BoxCollider2D>();
            box.transform.position = mousePos;
            box.size = new Vector2(0.1f, 0.1f);

        }
        if (Input.GetMouseButtonUp(0))
        {
            BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in colliders)
            {
                Destroy(box);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            col.gameObject.GetComponent<Animator>().Play("Bubble_01_Explosion");
            float time = col.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
            Collider2D collider = col.gameObject.GetComponent<Collider2D>();
            Destroy(collider);
            ScoreManager.instance.incrementScore();
            if (AudioManager.instance.sfx == true)
            {
                AudioManager.instance.Play("bubblepop");
            }
            Destroy(col.gameObject,time);
        }
         if(col.gameObject.tag == "Bomb")
        {
            col.gameObject.GetComponent<Animator>().Play("bomb explosion");
            Destroy(col.gameObject,1f);
            Invoke("GameOver", 0.5f);
        }
    }
    void GameOver() {
        gameManager.instance.GameOver();
    }
}

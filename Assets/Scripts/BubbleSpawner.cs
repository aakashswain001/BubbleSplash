using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {
    public GameObject[] balls;
    public float spawnTime;
    public float maxXpos;
    // Use this for initialization
    void Start () {
        StartSpawingBalls();
  }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StopSpawningBalls()
    {
        CancelInvoke("SpawnBall");
    }

    public void StartSpawingBalls()
    {
        InvokeRepeating("SpawnBall", 0.2f, spawnTime);
    }

    void SpawnBall()
    {
        int rand = Random.Range(0, 3);
        Instantiate(balls[rand], new Vector3( Random.Range(-maxXpos, maxXpos), transform.position.y, 0), Quaternion.identity);
    }
}

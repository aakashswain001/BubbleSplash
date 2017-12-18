using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour {
    public GameObject[] balls;
    public float spawnTime;
    public float maxXpos;
    int difficulty = 1;
    // Use this for initialization
    void Start () {
     
        StartSpawingBalls();
        if (AudioManager.instance.background == true)
        {
            AudioManager.instance.Play("game");
        }
        
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
        difficulty = DifficultyManager.instance.difficulty;
        if (difficulty < 2)
        {
            Spawn();
        }
        else
        {
            Spawn();
            int bomb = Random.Range(1, 20);
            if (bomb < 3)
            {
                Invoke("SpawnBomb", 0.1f);
            }
            else if (bomb < 5)
            {
                Invoke("SpawnStickBomb", 0.1f);
            }
           else if (bomb == 19) {
                Invoke("HappySpawn", 0.1f);
            }
           
        }
    }
    void Spawn() {
        Instantiate(balls[0], new Vector3(Random.Range(-maxXpos, maxXpos), transform.position.y, 0), Quaternion.identity);
    }
    void SpawnBomb() {
        Instantiate(balls[1], new Vector3(Random.Range(-maxXpos, maxXpos), transform.position.y, 0), Quaternion.identity);
    }
    void SpawnStickBomb() {
        Instantiate(balls[2], new Vector3(Random.Range(-maxXpos, maxXpos), transform.position.y, 0), Quaternion.identity);
    }
    void HappySpawn() {
        Instantiate(balls[3], new Vector3(Random.Range(-maxXpos, maxXpos), transform.position.y, 0), Quaternion.identity);
    }
}

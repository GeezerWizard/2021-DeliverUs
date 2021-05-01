using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private ScoreManager scoreManager;
    private Transform enemySpawnLocation;
    public GameObject enemyToSpawn;
    public int[] spawnDelay;
    private int currentArrayElement;
    private float gameTimer;
    private bool pauseTimer;
    
    private void Start()
    {
        scoreManager = GameObject.Find("Game Manager").GetComponent<ScoreManager>();
        scoreManager.AddToTotalEnemies(spawnDelay.Length);
        pauseTimer = false;
        currentArrayElement = 0;
        gameTimer = 0;
        enemySpawnLocation = this.transform;
    }
    
    private void Update()
    {
        if (pauseTimer == false)
        {
            gameTimer += Time.deltaTime;
            if (gameTimer > spawnDelay[currentArrayElement])
            {
                SpawnEnemy();
                if (currentArrayElement + 1 != spawnDelay.Length)
                {
                    currentArrayElement++;
                }
                else
                {
                    pauseTimer = true;
                }
                gameTimer = 0f;
            }
        }
    }
    private void SpawnEnemy()
    {
        Instantiate(enemyToSpawn, enemySpawnLocation.position, enemySpawnLocation.rotation);
    }
}

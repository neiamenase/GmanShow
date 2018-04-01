using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject enemy;                // The enemy prefab to be spawned.
    public float spawnTime = 10f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    public int maxEnemy = 10;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        int currentEnemy = 0;
        currentEnemy = GameObject.FindGameObjectsWithTag("Enermy").Length;
        if (currentEnemy > maxEnemy)
            return;

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        enemy.GetComponent<walker>().seen = true;

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        currentEnemy++;
    }
}
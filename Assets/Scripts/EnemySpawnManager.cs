using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnY, startDelay, spawnInterval;
    private float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        float camDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        minX = bottomCorner.x;
        maxX = topCorner.x;

        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        int selectedEnemy = Random.Range(0, enemies.Length);
        Vector3 spawnPosition = new Vector3(Random.Range(minX, maxX), spawnY, 0);
        Instantiate(enemies[selectedEnemy], spawnPosition, enemies[selectedEnemy].transform.rotation);
    }
}

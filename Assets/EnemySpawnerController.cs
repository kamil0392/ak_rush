using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    public float spawnRate;
    public GameObject prefab;

    float nextSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + 1 / spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextSpawnTime < Time.time)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y + Random.Range(-4.0f, 4.0f), 0f);
            Instantiate(prefab, spawnPos, transform.rotation);
            nextSpawnTime = Time.time + 1 / spawnRate;
        }
    }
}

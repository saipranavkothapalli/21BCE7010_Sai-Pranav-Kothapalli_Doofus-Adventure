using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuplitReplacement : MonoBehaviour
{
    public float pulpit_spawn_time = 2.5f;
    public GameObject reference;
    private int possiblecube = 2;
    public int count = 0;
    private Vector3 lastSpawnedPosition;

    private float lastSpawnTime;
    private float minTimeBetweenSpawns = 2.5f;
    void Awake()
    {
        lastSpawnedPosition = new Vector3(0, 0, 0);
        Instantiate(reference, lastSpawnedPosition, Quaternion.identity);
        lastSpawnTime = Time.time;
        count++;
    }
    void FixedUpdate()
    {
        if (count < possiblecube && Time.time - lastSpawnTime >= minTimeBetweenSpawns)
        {
            StartCoroutine(Spawn());
            count++;
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(pulpit_spawn_time);
        CubeSpawning();
    }

    void CubeSpawning()
    {
        Vector3[] adjacentPositions = new Vector3[]
        {
            new Vector3(lastSpawnedPosition.x + 5f, lastSpawnedPosition.y, lastSpawnedPosition.z),
            new Vector3(lastSpawnedPosition.x - 5f, lastSpawnedPosition.y, lastSpawnedPosition.z),
            new Vector3(lastSpawnedPosition.x, lastSpawnedPosition.y, lastSpawnedPosition.z + 5f),
            new Vector3(lastSpawnedPosition.x, lastSpawnedPosition.y, lastSpawnedPosition.z - 5f)
        };

        int randomIndex = Random.Range(0, adjacentPositions.Length);
        lastSpawnedPosition = adjacentPositions[randomIndex];
        Instantiate(reference, lastSpawnedPosition, Quaternion.identity);
        lastSpawnTime = Time.time;
    }
}

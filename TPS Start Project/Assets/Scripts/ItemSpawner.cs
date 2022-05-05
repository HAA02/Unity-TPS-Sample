using UnityEngine;
using UnityEngine.AI;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items;
    public Transform playerTransform;
    
    private float lastSpawnTime;
    public float maxDistance = 5f;
    
    private float timeBetSpawn;

    public float timeBetSpawnMax = 7f;
    public float timeBetSpawnMin = 2f;

    private void Start()
    {
        timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);
        lastSpawnTime = 0f;
    }

    private void Update()
    {
        if(Time.time >= lastSpawnTime + timeBetSpawn && playerTransform != null)
        {
            Spawn();
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

        }
    }

    private void Spawn()
    {
        var spwanPosition = Utility.GetRandomPointOnNavMesh(playerTransform.position, maxDistance, NavMesh.AllAreas);
        var item = Instantiate(items[Random.Range(0, items.Length)], spwanPosition, Quaternion.identity);
        Destroy(item, 5f);

        spwanPosition += Vector3.up + 0.5f;
    }
}
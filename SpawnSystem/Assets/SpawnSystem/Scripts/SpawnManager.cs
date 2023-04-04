using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Already Created SpawnPoints")]
    public bool spawnCreated;
    public string[] spawnTag;
    public GameObject[] spawnPointsCreated;

    [Header("Create Random Spawns Already Made")]
    public bool spawnRandomMade;
    public int spawnCount;
    public Vector3 spawnArea;
    public GameObject[] prfbsSpawn;  
    public GameObject[] spawnPointsRandom;

    [Header("Create Random SpawnAreas")]
    public bool spawnRandom;
    public int spawnRandomCount;
    public Vector3 spawnRandomArea;
    public Color spawnRandomAreaColor;
    public GameObject[] spawnPointsGenerated;
    private Gizmos spawnRandomGizmos;

    [Header("Seed Management")]
    public string seed = "Default";
    public int currentSeed = 0;

    public GameObject[] allSpawnsGet
    {
        get => allSpawns;
    }

    private int a = 0;
    private int b = 0;
    private GameObject spawn;
    private GameObject[] allSpawns;

    // Start is called before the first frame update
    void Start()
    {
        SetSpawners();
        SetAllSpawners();
    }

    private void SetSpawners()
    {
        if (spawnCreated)
        {
            foreach (var spawnTag in spawnTag)
            {
                var tagged = GameObject.FindGameObjectsWithTag(spawnTag);
                spawnPointsCreated = new GameObject[tagged.Length];

                for (int i = 0; i < tagged.Length; i++)
                {
                    spawnPointsCreated[a] = tagged[i];
                    a++;
                }
            }
        }

        if (spawnRandomMade)
        {
            spawnPointsRandom = new GameObject[spawnCount];
            for (int i = 0; i < spawnCount; i++)
            {
                spawn = prfbsSpawn[Random.Range(0, prfbsSpawn.Length)];
                var pos = new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), Random.Range(-spawnArea.z, spawnArea.z));
                var spawner = Instantiate(spawn, pos, Quaternion.identity);
                spawner.transform.SetParent(transform);
                spawnPointsRandom[i] = spawner;
            }
        }

        if (spawnRandom)
        {
            spawnPointsGenerated = new GameObject[spawnRandomCount];
        }
    }

    private void SetAllSpawners()
    {
        allSpawns = new GameObject[spawnPointsCreated.Length + spawnPointsRandom.Length];

        foreach (var spawnCreated in spawnPointsCreated)
        {
            allSpawns[b] = spawnCreated;
            b++;
        }

        foreach (var spawnRandom in spawnPointsRandom)
        {
            allSpawns[b] = spawnRandom;
            b++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnArea.x * 2, spawnArea.y * 2, spawnArea.z * 2));
    }
}

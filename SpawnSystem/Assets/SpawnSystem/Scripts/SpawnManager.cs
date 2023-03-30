using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Already Created SpawnPoints")]
    public bool spawnAreaCreated;
    public string[] spawnAreaTag;
    public GameObject[] spawnPointsCreated;

    [Header("Create Random SpawnPoints")]
    public bool spawnAreaRandom;
    public int spawnAreaCount;
    public float valueX;
    public float valueY;
    public float valueZ;
    public GameObject[] prfbsSpawn;    
    public GameObject[] spawnPointsRandom;


    // Start is called before the first frame update
    void Start()
    {
        if (spawnAreaCreated)
        {
            int a = 0;
            foreach (var spawnTag in spawnAreaTag)
            {
                var tagged = GameObject.FindGameObjectsWithTag(spawnTag);
                
                for(int i = 0; i < tagged.Length; i++)
                {
                    spawnPointsCreated[a] = tagged[i];
                    a++;
                }
            }
        }

        if (spawnAreaRandom)
        {
            for(int i = 0; i < spawnAreaCount; i++)
            {
                var spawn = prfbsSpawn[Random.Range(0, prfbsSpawn.Length)];
                var pos = new Vector3(Random.Range(-valueX, valueX), Random.Range(-valueY, valueY), Random.Range(-valueZ, valueZ));
                var spawner = Instantiate(spawn, pos, Quaternion.identity);
                spawner.transform.SetParent(transform);
                spawnPointsRandom[i] = spawner;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(valueX * 2, valueY * 2, valueZ * 2));
    }
}

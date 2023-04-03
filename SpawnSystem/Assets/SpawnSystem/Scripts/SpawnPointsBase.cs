using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnType
{
    AREA, POINTS
}

public class SpawnPointsBase : MonoBehaviour
{
    public SpawnType spawnType;
    public GameObject[] prfbs;
    public int objects;
    public float timeMin;
    public float timeMax;
    public float offset = 0.5f;
    public GameObject[] spawned;

    [Header("Range for AreaSpawn")]
    public Vector3 RangeSpawn;

    private int obj;
    private float time;
    private bool spawning = true;
    private bool posUsed;
    private GameObject choosed;
    private GameObject spawnedObject;
    public Transform[] spawnPoints;
    private Vector3 posSelected;
    private BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        spawned = new GameObject[objects];
        //boxCollider = GetComponent<BoxCollider>();
        //boxCollider.enabled = false;
        if(spawnType == SpawnType.POINTS)
        {
            spawnPoints = GetComponentsInChildren<Transform>();
        }

        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(obj >= objects)
        {
            spawning = false;
        }
        else
        {
            spawning = true;
        }
    }

    public IEnumerator Spawn()
    {
        while (spawning)
        {
            switch (spawnType)
            {
                case SpawnType.AREA:
                    time = Random.Range(timeMin, timeMax);
                    choosed = prfbs[Random.Range(0, prfbs.Length)];

                    posSelected = new Vector3(Random.Range(-RangeSpawn.x, RangeSpawn.x), Random.Range(-RangeSpawn.y, RangeSpawn.y), Random.Range(-RangeSpawn.z, RangeSpawn.z)) + transform.position;

                    //CheckSpawnPosition(posSelected);
                    NewObject(posSelected);

                    yield return new WaitForSeconds(time);
                    break;

                case SpawnType.POINTS:
                    time = Random.Range(timeMin, timeMax);
                    choosed = prfbs[Random.Range(0, prfbs.Length)];
                    posSelected = spawnPoints[Random.Range(1, spawnPoints.Length)].position;

                    //CheckSpawnPosition(posSelected);
                    NewObject(posSelected);

                    yield return new WaitForSeconds(time);
                    break;
            }
        }
    }

    private void NewObject(Vector3 pos)
    {        
        spawnedObject = Instantiate(choosed, pos, Quaternion.identity);
        spawnedObject.transform.SetParent(transform);
        spawned[obj] = spawnedObject;
        obj++;
        Debug.Log("New object spawned at " + pos);
    }

    private void CheckSpawnPosition(Vector3 checkPos)
    {
        boxCollider.enabled = true;
        boxCollider.center = checkPos;
        new WaitForSeconds(0.1f);
        boxCollider.enabled = false;

        if (posUsed)
        {
            var i = Mathf.RoundToInt(Random.Range(1, 4));
            Debug.Log("The selected position is already use. Offset added.");
            switch (i)
            {
                case 1:
                    posSelected.z += offset;
                    break;

                case 2:
                    posSelected.x -= offset;
                    break;
                    
                case 3:
                    posSelected.z -= offset;
                    break;

                case 4:
                    posSelected.x += offset;
                    break;
            }
        }

        posUsed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        posUsed = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if(spawnType == SpawnType.AREA)
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(RangeSpawn.x * 2, RangeSpawn.y * 2, RangeSpawn.z * 2));
        }
    }
}
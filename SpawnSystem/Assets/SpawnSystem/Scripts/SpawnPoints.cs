using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsBase : MonoBehaviour
{
    public GameObject[] prfbs;
    public int objects;
    public float timeMin;
    public float timeMax;
    public float valueX;
    public float valueY;
    public float valueZ;

    public GameObject[] spawned;
    private int obj;
    private bool spawning = true;
    private Vector3 range;

    // Start is called before the first frame update
    void Start()
    {
        spawned = new GameObject[objects];
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        if(obj >= objects)
        {
            spawning = false;
        }
    }

    public IEnumerator Spawn()
    {
        while (spawning)
        {
            var time = Random.Range(timeMin, timeMax);
            var choosed = prfbs[Random.Range(0, prfbs.Length)];

            var x = Random.Range(-valueX, valueX);
            var y = Random.Range(-valueY, valueY);
            var z = Random.Range(-valueZ, valueZ);
            range.x = x;
            range.y = y;
            range.z = z;

            var spawnedObject = Instantiate(choosed, range, Quaternion.identity);
            spawnedObject.transform.SetParent(transform);
            spawned[obj] = spawnedObject;
            obj++;
            Debug.Log("New object spawned at " + range);
            yield return new WaitForSeconds(time);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(valueX * 2, valueY * 2, valueZ * 2));
    }
}

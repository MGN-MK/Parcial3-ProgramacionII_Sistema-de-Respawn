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
    public float valueZ;

    private int obj;
    private bool spawning = true;
    private Vector3 range;

    // Start is called before the first frame update
    void Start()
    {
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
            var z = Random.Range(-valueZ, valueZ);
            range.x = x;
            range.z = z;

            var spawnedObject = Instantiate(choosed, range, Quaternion.identity);
            obj++;
            Debug.Log("New object spawned at " + range);
            yield return new WaitForSeconds(time);
        }
    }
}

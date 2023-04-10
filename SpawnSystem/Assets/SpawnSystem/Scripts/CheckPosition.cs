using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    public float offset = 1f;
    public float speed;
    public string floortag;
    public Vector3 posSpawn;

    private Vector3 posSelected;

    private void Start()
    {
        posSelected = transform.position;
        posSpawn = transform.position;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != floortag)
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

            transform.position = Vector3.MoveTowards(transform.position, posSelected, Time.deltaTime);
        }
    }
}

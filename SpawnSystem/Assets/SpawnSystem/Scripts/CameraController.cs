using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{  
    public float sensitivity = 15f;
    public float speed;

    private float rotationX = 0f;
    private float rotationY = 0f;
    private float moveX;
    private float moveZ;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);

        moveX = Input.GetAxisRaw("Horizontal");
        moveZ = Input.GetAxisRaw("Vertical");
        rb.AddForce(moveZ * transform.forward * speed);
        rb.AddForce(moveX * transform.right * speed);
    }
}

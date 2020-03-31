using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollFeet : MonoBehaviour
{
    public float speed = 100f;
    Vector3 input = new Vector3(0,0,0);
    public Rigidbody rb;
    Vector3 offset = new Vector3(0,0,0);

    void Start()
    {
        offset = transform.position - rb.position;
    }

    void FixedUpdate()
    {
        rb.AddForce(input*speed);
    }

    // Update is called once per frame
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"),0,0);
        transform.position = offset + rb.position;
    }
}

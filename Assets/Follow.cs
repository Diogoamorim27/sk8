using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform ObjectToFollow;

    void FixedUpdate()
    {
        transform.position = ObjectToFollow.position;
    }
}

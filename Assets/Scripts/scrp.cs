using UnityEngine;

public class scrp : MonoBehaviour
{
    public float RotateSpeed = 0.01f;
    
    void FixedUpdate()
    {
        transform.Rotate(0,0,RotateSpeed);
    }
}

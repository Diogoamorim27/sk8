using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TruckInfo
{
    public WheelCollider leftWheelCol;
    public WheelCollider rightWheelCol;
    public Transform leftWheelT;
    public Transform rightWheelT;
}

public class Skate : MonoBehaviour
{
    Rigidbody rb;
 
    public List<TruckInfo> truckInfos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        //rb.AddForce(new Vector3(0,0,-10));
    
        foreach (TruckInfo truckInfo in truckInfos)
        {
    
            truckInfo.leftWheelCol.motorTorque = -1f;
            truckInfo.rightWheelCol.motorTorque = -1f;
            ApplyWheelRotation(truckInfo);
        }
    }  

    public void ApplyWheelRotation(TruckInfo truck)
    {
        Vector3 position;
        Quaternion rotation;

        truck.leftWheelCol.GetWorldPose(out position, out rotation);
    
        truck.leftWheelT.transform.position = position;
        truck.leftWheelT.transform.rotation = rotation;

        truck.rightWheelCol.GetWorldPose(out position, out rotation);
        
        truck.rightWheelT.transform.position = position;
        truck.rightWheelT.transform.rotation = rotation;
    }
}

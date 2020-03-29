using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetMovement : MonoBehaviour
{
    PlayerControls controls;

    public Rigidbody backFoot = null;
    public Rigidbody frontFoot = null;
    
    public Vector3 rearPosOffset = new Vector3(0.24f,0.04f,-0.46f);
    Vector3 rearRotOffset = new Vector3(0,90f,-18.42f);

    public Vector3 frontPosOffset = new Vector3(0.02f,0f,-0.04f);
    Vector3 frontRotOffset = new Vector3(0f,90f,1.52f);

    Vector3 rearRowPos;
    Quaternion rearRowRot;

    Vector3 frontRowPos;
    Quaternion frontRowRot;

    Vector2 leftInput;
    
    bool row = false;

    public float transitionSpeed = 0.003f;

    public Vector2 LeftInput { get => leftInput; set => leftInput = value; }

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.RightShoulder.performed += ctx => row = true;
        controls.Gameplay.RightShoulder.canceled += ctx => row = false;

        controls.Gameplay.LeftStick.performed += ctx => leftInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.LeftStick.canceled += ctx => leftInput = Vector2.zero;

    }
    // Start is called before the first frame update
    void Start()
    {
        rearRowPos = backFoot.transform.position;
        rearRowRot = backFoot.transform.rotation;

        frontRowPos = frontFoot.transform.position;
        frontRowRot = frontFoot.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(leftInput);
    }

    void FixedUpdate()
    {
        if (row)
        {   
            if (backFoot.transform.position != rearRowPos)
            {         
                backFoot.MovePosition(Vector3.Lerp(backFoot.transform.position, rearRowPos, transitionSpeed));
                backFoot.MoveRotation(Quaternion.Lerp(backFoot.transform.rotation, rearRowRot, transitionSpeed));
            }
            

            frontFoot.MovePosition(Vector3.Lerp(frontFoot.transform.position, frontRowPos, transitionSpeed));
            frontFoot.MoveRotation(Quaternion.Lerp(frontFoot.transform.rotation, frontRowRot, transitionSpeed));
        }
        else 
        {
            backFoot.MovePosition(Vector3.Lerp(backFoot.transform.position, rearRowPos - rearPosOffset, transitionSpeed));
            backFoot.MoveRotation(Quaternion.Lerp(backFoot.transform.rotation, Quaternion.Euler(rearRowRot.eulerAngles + rearRotOffset), transitionSpeed));
       
            frontFoot.MovePosition(Vector3.Lerp(frontFoot.transform.position, frontRowPos - frontPosOffset, transitionSpeed));
            frontFoot.MoveRotation(Quaternion.Lerp(frontFoot.transform.rotation, Quaternion.Euler(frontRowRot.eulerAngles + frontRotOffset), transitionSpeed));
        }
    }
    
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}

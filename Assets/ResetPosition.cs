using UnityEngine;
using UnityEngine.InputSystem;

public class ResetPosition : MonoBehaviour
{
    public Transform Skateboard;
    public Transform LeftFoot;
    public Transform RightFoot;

    PlayerControls controls;

    Vector3 SkatePos;
    Quaternion SkateRot;
    Quaternion Rot;
    Vector3 Pos;
    Vector3 LeftPos;
    Quaternion LeftRot;
    Vector3 RightPos;
    Quaternion RightRot;


    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.ResetSkatePos.performed += ctx => ResetPos();
    }

    void Start()
    {
        Pos = transform.position;
        Rot = transform.rotation;
        SkatePos = Skateboard.transform.position;
        SkateRot = Skateboard.transform.rotation;
        LeftPos = LeftFoot.transform.position;
        LeftRot = LeftFoot.transform.rotation;
        RightPos = RightFoot.transform.position;
        RightRot = RightFoot.transform.rotation;

    }

    void ResetPos()
    {
        transform.position = Pos;
        transform.rotation = Rot;
        Skateboard.transform.position = SkatePos;
        Skateboard.transform.rotation = SkateRot;
        LeftFoot.transform.position = LeftPos;
        LeftFoot.transform.rotation = LeftRot;
        RightFoot.transform.position = RightPos;
        RightFoot.transform.rotation = RightRot;
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

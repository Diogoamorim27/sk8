using UnityEngine;
using UnityEngine.InputSystem;

//obs levar em conta a gravidade

public class MoveFeet : MonoBehaviour
{
    PlayerControls controls;

    public Rigidbody leftFoot;
    public Rigidbody rightFoot;

    //public Transform Skateboard;

    public float movementRange = 1f;
    public float moveSpeed = 0.1f;

    Vector3 originalLeftPos;
    Vector3 originalRightPos;

    Vector2 leftInput;
    Vector2 rightInput;

    Vector3 leftInput3d = new Vector3();
    Vector3 rightInput3d = new Vector3();

    //float LeftOffset;
    //float RightOffset;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.RightStick.performed += ctx => rightInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.RightStick.canceled += ctx => rightInput = Vector2.zero;

        controls.Gameplay.LeftStick.performed += ctx => leftInput = ctx.ReadValue<Vector2>();
        controls.Gameplay.LeftStick.canceled += ctx => leftInput = Vector2.zero;
    }
    
    void Start()
    {
        originalLeftPos = leftFoot.position;
        originalRightPos = rightFoot.position;
        
    }
    
    void Update()
    {
        leftInput3d.x = leftInput.x;
        leftInput3d.y = leftInput.y;
        rightInput3d.x = rightInput.x;
        rightInput3d.y = rightInput.y;

    }

    void FixedUpdate()
    {
        leftFoot.MovePosition(Vector3.Lerp(leftFoot.position, originalLeftPos + leftInput3d * movementRange, moveSpeed));
        rightFoot.MovePosition(Vector3.Lerp(rightFoot.position, originalRightPos + rightInput3d * movementRange, moveSpeed));
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

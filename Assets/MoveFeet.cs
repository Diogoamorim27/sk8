using UnityEngine;
using UnityEngine.InputSystem;

//obs levar em conta a gravidade

public class MoveFeet : MonoBehaviour
{
    PlayerControls controls;

    [SerializeField] private Transform objectToFollow;
    private float leftFootXOffset = 0.1f;
    private float rightFootXOffset = 0.1f;
    private float leftFootYOffset = 0.1f;
    private float rightFootYOffset = 0.1f;

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
        leftFootXOffset = originalLeftPos.x - objectToFollow.position.x;
        rightFootXOffset = originalRightPos.x - objectToFollow.position.x;
        leftFootYOffset = originalLeftPos.y - objectToFollow.position.y;
        rightFootYOffset = originalRightPos.y - objectToFollow.position.y;
        
        ResetOriginalPos();
    }

    void Update()
    {
        leftInput3d.x = leftInput.x/2;
        leftInput3d.y = leftInput.y;
        rightInput3d.x = rightInput.x/2;
        rightInput3d.y = rightInput.y;

        ResetOriginalPos();
    }

    void FixedUpdate()
    {
        leftFoot.MovePosition(Vector3.Lerp(leftFoot.position, originalLeftPos + leftInput3d * movementRange, moveSpeed));
        rightFoot.MovePosition(Vector3.Lerp(rightFoot.position, originalRightPos + rightInput3d * movementRange, moveSpeed));
    }

    void ResetOriginalPos()
    {
        originalLeftPos = GetFollowedObjectPos(originalLeftPos, leftFootXOffset);
        originalRightPos = GetFollowedObjectPos(originalRightPos, rightFootXOffset);
    }

    /// <summary>
    /// Method that returns the new origin position
    /// </summary>
    /// <param name="origin">Original position</param>
    /// <returns>Position that contains the destiny x</returns>
    Vector3 GetFollowedObjectPos(Vector3 origin, float offset)
    {
        Vector3 destiny = new Vector3(objectToFollow.position.x + offset, origin.y, origin.z);
        return destiny;
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

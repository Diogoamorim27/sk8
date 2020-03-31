using UnityEngine;

public class FeetMovement : MonoBehaviour
{
    PlayerControls controls;
    Rigidbody rb;

    float frontXOffset;

    public Rigidbody backFoot = null;
    public Rigidbody frontFoot = null;

    public Rigidbody skateRb = null;

    public BoxCollider skateCollider = null;
    public BoxCollider backFootCollider = null;

    public Vector2 rowRange = new Vector2(1f,0.5f);
    public Vector3 rowTilt = new Vector3(45f,45f,45f);
    
    public Vector3 rearPosOffset = new Vector3(0.24f,0.04f,-0.46f);
    Vector3 rearRotOffset = new Vector3(0,90f,-18.42f);

    public Vector3 frontPosOffset = new Vector3(0.02f,0f,-0.04f);
    Vector3 frontRotOffset = new Vector3(0f,90f,1.52f);

    Vector3 rearRowPos;
    Quaternion rearRowRot;

    Vector3 frontRowPos;
    Quaternion frontRowRot;

    Vector3 rearRestPosition;
    Quaternion rearRestRotation;

    Vector3 frontRestPosition;
    Quaternion frontRestRotation;

    public float rowForce = 10f;

    Vector2 leftInput;
    
    bool row = false;
    bool backFootHitFloor = false;

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
        rb = GetComponent<Rigidbody>();
        rearRowRot = backFoot.transform.rotation;
        rearRowPos = backFoot.transform.position;

        frontRowPos = frontFoot.transform.position;
        frontRowRot = frontFoot.transform.rotation;

        frontXOffset = frontRowPos.x - skateRb.position.x;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(leftInput);
    }

    void FixedUpdate()
    {
        if (row)
        {   
            if (!backFootHitFloor)
            {
                rearRestPosition = rearRowPos + new Vector3(leftInput.x * rowRange.x, leftInput.y * rowRange.y, 0);
            }
            else if (Mathf.Abs(leftInput.x) > 0.05)
            {
                skateRb.AddForce(new Vector3(leftInput.x, 0, 0) * -rowForce);
            }

            if(leftInput.y > 0)
            {
                backFootHitFloor = false;
            }

            Vector3 tiltOffset = rowTilt * leftInput.x;
            tiltOffset.x = Mathf.Abs(tiltOffset.x);
            rearRestRotation = Quaternion.Euler(rearRowRot.eulerAngles + tiltOffset);

            frontRestPosition = frontRowPos;
            frontRestRotation = frontRowRot;
        }
        else 
        {
            Physics.IgnoreCollision(skateCollider, backFootCollider);

            rearRestPosition =  rearRowPos - rearPosOffset;
            rearRestRotation = Quaternion.Euler(rearRowRot.eulerAngles + rearRotOffset);
       
            frontRestPosition = frontRowPos - frontPosOffset;
            frontRestRotation =  Quaternion.Euler(frontRowRot.eulerAngles + frontRotOffset);
        }


        frontFoot.MovePosition(Vector3.Lerp(frontFoot.transform.position, frontRestPosition, transitionSpeed));
        frontFoot.MoveRotation(Quaternion.Lerp(frontFoot.transform.rotation, frontRestRotation, transitionSpeed));

        backFoot.MovePosition(Vector3.Lerp(backFoot.transform.position, rearRestPosition, transitionSpeed));
        backFoot.MoveRotation(Quaternion.Lerp(backFoot.transform.rotation, rearRestRotation, transitionSpeed));

    }

    public void BackFootCollided(Collision col)
    {
        backFootHitFloor = true;
        Debug.Log("hit floor!");        
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

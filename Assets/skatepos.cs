using UnityEngine;

public class skatepos : MonoBehaviour
{
    PlayerControls controls;
    
    Rigidbody rb;
    public Material wheelMat = null;
    public WheelCollider someWheel = null;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float ang_vel = rb.velocity.x/(2*Mathf.PI*someWheel.radius);
        wheelMat.SetFloat("Vector1_69FE433B", ang_vel);


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

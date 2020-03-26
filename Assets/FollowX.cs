using UnityEngine;

public class FollowX : MonoBehaviour
{
    public Transform ObjectToFollow;

    void FixedUpdate()
    {
        transform.position = new Vector3(ObjectToFollow.position.x, transform.position.y, transform.position.z);
    }
}

using UnityEngine;

public class BackFoot : MonoBehaviour
{
    public void OnCollisionEnter(Collision col)
    {
        transform.parent.GetComponent<FeetMovement>().BackFootCollided(col);
    }
}

using UnityEngine;

public class SpriteFollow : MonoBehaviour
{
    public Transform target1;      // The player object
    public float smoothTime = 0.3f; // Time to reach target (lower = snappier)


    private Vector3 velocity = Vector3.zero;

    void Start(){
    }

    void LateUpdate()
    {

        if(target1 != null)
        {
        transform.position = target1.position;
        transform.rotation = target1.rotation * Quaternion.Euler(0, 0, 45);
        }
        


        
    }

}

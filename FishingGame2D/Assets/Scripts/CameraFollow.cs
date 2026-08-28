using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target1;      // The player object
    public Transform target2; //lure
    public Vector3 offset = new Vector3(0, 2, -10); // Camera offset
    public float smoothTime = 0.3f; // Time to reach target (lower = snappier)

    public bool player;
    public bool lure;

    private Vector3 velocity = Vector3.zero;

    void Start(){
        player = true;
    }

    void LateUpdate()
    {
        if(player){
Vector3 desiredPosition = target1.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        }

        else if(lure){
            Vector3 desiredPosition = target2.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        }
        
    }

    public void FollowPlayer(){
        player = true;
        lure = false;
    }

    public void FollowLure(){
        lure = true;
        player = false;
    }
}

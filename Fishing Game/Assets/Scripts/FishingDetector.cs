using UnityEngine;
using TarodevController;

public class FishingDetector : MonoBehaviour
{

public bool ready; 
public PlayerController PlayerControllerScript;
public LureMovement LureMovement;
public CameraFollow CameraFollow;


void OnTriggerEnter2D()
{
    ready = true;
}

void OnTriggerExit2D(){
    ready = false;
}

void Update(){
    if (Input.GetKeyDown(KeyCode.E) && ready && PlayerControllerScript.enabled)
        {
            PlayerControllerScript.enabled = false;
            LureMovement.enabled = true;
            CameraFollow.FollowLure();
        }
    else if(Input.GetKeyDown(KeyCode.E) && ready && !PlayerControllerScript.enabled){
        PlayerControllerScript.enabled = true;
        LureMovement.enabled = false;
        CameraFollow.FollowPlayer();
        LureMovement.ResetLure();
    }
}
}

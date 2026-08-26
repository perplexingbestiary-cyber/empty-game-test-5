using UnityEngine;
using TarodevController;

public class FishingDetector : MonoBehaviour
{

public bool ready; 
public float currentTime;
public bool fishingTime;
public bool fightingTime;

public PlayerController PlayerControllerScript;
public LureMovement LureMovement;
public CameraFollow CameraFollow;
public LineMovement LineMovement;
public MeshRenderer Lure;
public GameObject Line;
public ShopDetector shopDetector;


void Start()
    {
        StartFishingTime();
    }
void OnTriggerEnter2D(Collider2D other)
{
        if (other.CompareTag("Player"))
        {
            ready = true;
        }
    
}

void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("Player"))
        {
            ready = false;
        }
}

void Update()
{
    if(fishingTime || fightingTime)
        {
            currentTime += Time.deltaTime;
        }
    
    if (Input.GetKeyDown(KeyCode.E) && ready && PlayerControllerScript.enabled && fishingTime)
    {
        StartFishing();
    }
    else if(Input.GetKeyDown(KeyCode.E) && ready && !PlayerControllerScript.enabled && fishingTime)
    {
        StopFishing();
    }

    if(currentTime >= 300f && fishingTime)
        {
            StopFishing();
            StopFishingTime();
            currentTime = 0;
        }
    
    if(currentTime >= 10f && fightingTime)
        {
            StartFishing();
            StartFishingTime();
            currentTime = 0;
        }
    
}

public void StopFishing()
    {
        PlayerControllerScript.enabled = true;
        LureMovement.enabled = false;
        LineMovement.enabled = false;

        Line.SetActive(false);
        Lure.enabled = false;

        CameraFollow.FollowPlayer();
        LureMovement.ResetLure();
        LineMovement.ResetLine();

        
    }
public void StartFishing()
    {
        PlayerControllerScript.enabled = false;
            LureMovement.enabled = true;
            LineMovement.enabled = true;

            Line.SetActive(true);
            Lure.enabled = true;

            CameraFollow.FollowLure();
    }

public void StartFishingTime()
    {
        fishingTime = true;
        shopDetector.StartFishingTime();
    }
public void StopFishingTime()
    {
        fishingTime = false;
        fightingTime = true;
        shopDetector.StopFishingTime();
    }
}

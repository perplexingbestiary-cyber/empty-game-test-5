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
public RequestController requestController;

public SpriteRenderer Lure;
public GameObject SpecLure;
public SpriteRenderer Pole;
public GameObject Line;
public ShopDetector shopDetector;
public GameObject Light;
public GameObject E;

public bool noLine = false;
public bool specLure = false;
public bool off;


void Start()
    {
        StartFishingTime();
    }
void OnTriggerEnter2D(Collider2D other)
{
        if (other.CompareTag("Player"))
        {
            ready = true;
            E.SetActive(true);
            
        }
    
}

void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("Player"))
        {
            ready = false;
            E.SetActive(false);
        }
}

void Update()
{
    if (noLine)
        {
            if(Lure.enabled || SpecLure.activeSelf)
            {
                StopFishing();
            }
            
        }

    if(fishingTime)// || fightingTime)
        {
            currentTime += Time.deltaTime;
        }
    
    if (Input.GetKeyDown(KeyCode.E) && ready && PlayerControllerScript.enabled)
    {
        StartFishing();
        E.SetActive(false);
        off = true;
    }

    else if(Input.GetKeyDown(KeyCode.E) && ready && off)
    {
       // Debug.Log("E");
        StopFishing();
        E.SetActive(true);
        off = false;
        
    }
//Debug.Log(!PlayerControllerScript.enabled);
        
/*
    if(currentTime >= 150f && fishingTime)
        {
            StopFishing();
            StopFishingTime();
            currentTime = 0;
        }
*/

    /*
    if(currentTime >= 10f && fightingTime)
        {
            StartFishing();
            StartFishingTime();

            currentTime = 0;
        }
   */ 
}

public void StopFishing()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/StopFishing", gameObject);
        //Debug.Log("E");
        PlayerControllerScript.enabled = true;
        LureMovement.Stop();
        //LureMovement.enabled = false;
        LineMovement.enabled = false;

        Light.SetActive(false);

        Line.SetActive(false); 
        Lure.enabled = false;
        SpecLure.SetActive(false);
        Pole.enabled = false;

        CameraFollow.FollowPlayer();
        LureMovement.ResetLure();
        LineMovement.ResetLine();

        
    }
public void StartFishing()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/StartFishing", gameObject);
            PlayerControllerScript.enabled = false;
            LureMovement.Go();
            LineMovement.enabled = true;

            Light.SetActive(true);

            Line.SetActive(true);
            
        if (!specLure)
        {
            Lure.enabled = true;
            Pole.enabled = true;
        }    
        else
        {
            SpecLure.SetActive(true);
            Pole.enabled = true;
        }

            CameraFollow.FollowLure();
    }

public void StartFishingTime()
    {
        fishingTime = true;
       // fightingTime = false;
       // shopDetector.StartFishingTime();
    }
public void StopFishingTime()
    {
       // fishingTime = false;
       // fightingTime = true;
       // shopDetector.StopFishingTime();
       // requestController.ClosingTime();
        
    }
public void NoLine()
    {
        noLine = true;
    }
public void YesLine()
    {
        noLine = false;
    }
public void NoSpecLure()
    {
        specLure = false;
        if (SpecLure.activeSelf)
        {
            Lure.enabled = true;
            SpecLure.SetActive(false);
        }
    }
public void YesSpecLure()
    {
        specLure = true;
    }
}

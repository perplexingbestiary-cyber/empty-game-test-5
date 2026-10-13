using UnityEngine;
using TarodevController;
using TMPro;

public class ShopDetector : MonoBehaviour
{
public bool ready; 
public float currentTime;
public bool fishingTime;
public bool fightingTime;

public PlayerController PlayerControllerScript;
public RequestController requestController;
public LureMovement lureMovement;

public GameObject Shop;
public GameObject E;

public GameObject Lure1;
public GameObject Lure2;
public GameObject Lure3;
public GameObject SpecLure;







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
            if(E != null)
            {
               E.SetActive(false); 
            }
            
            StopShopping();
        }
}

void Update()
{
    
    
    if (Input.GetKeyDown(KeyCode.E) && ready && PlayerControllerScript.enabled)// && fishingTime)
    {
        if(lureMovement.line == 0)
        {
            Lure1.SetActive(false);
            Lure2.SetActive(false);
            Lure3.SetActive(false);
        }
        else if(lureMovement.line == 1)
        {
            Lure1.SetActive(true);
            Lure2.SetActive(false);
            Lure3.SetActive(false);
        }
        else if(lureMovement.line == 2)
        {
            Lure1.SetActive(true);
            Lure2.SetActive(true);
            Lure3.SetActive(false);
        }
        else if(lureMovement.line == 3)
        {
            Lure1.SetActive(true);
            Lure2.SetActive(true);
            Lure3.SetActive(true);
        }
        if(lureMovement.specLure == 1)
            {
                SpecLure.SetActive(true);
            }
            else
            {
                SpecLure.SetActive(false);
            }

                
            
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/ShopOpen", gameObject);
        StartShopping();
        requestController.MenuOpen();

        
    }
    else if(Input.GetKeyDown(KeyCode.E) && ready && !PlayerControllerScript.enabled)// && fishingTime)
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/ShopClose", gameObject);
        StopShopping();
        requestController.MenuClosed();
            
    }

   
    
}

public void StopShopping()
    {
        PlayerControllerScript.enabled = true;
        

        Shop.SetActive(false);
        

        
    }
public void StartShopping()
    {
        PlayerControllerScript.enabled = false;
            

        Shop.SetActive(true);
            
    }

public void StartFishingTime()
    {
       // fishingTime = true;
    }
public void StopFishingTime()
    {
      //  fishingTime = false;
    }
}

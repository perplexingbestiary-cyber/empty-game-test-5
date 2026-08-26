using UnityEngine;
using TarodevController;

public class ShopDetector : MonoBehaviour
{
public bool ready; 
public float currentTime;
public bool fishingTime;
public bool fightingTime;

public PlayerController PlayerControllerScript;

public GameObject Shop;



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
    
    
    if (Input.GetKeyDown(KeyCode.E) && ready && PlayerControllerScript.enabled && fishingTime)
    {
        StartShopping();
    }
    else if(Input.GetKeyDown(KeyCode.E) && ready && !PlayerControllerScript.enabled && fishingTime)
    {
        StopShopping();
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
        fishingTime = true;
    }
public void StopFishingTime()
    {
        fishingTime = false;
    }
}

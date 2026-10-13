using UnityEngine;

public class LeverController : MonoBehaviour
{
    public bool ready;
    public bool stormReady;
    public bool storming;

    
    public GameObject Fish5;
    //public GameObject BigFish;
    public float fishSpawnY;
    public int fishSpawnX; 

    public float currentTime;
    public float stormTime;
    public float waitTime;

    public GameObject lightJam;
    public GameObject darkJam;

    public GameObject LeverOn;
    public GameObject LeverOff;
    public GameObject E;

    public CameraFollow cameraFollow;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ready = true;
            if (waitTime >= 60)
            {
                E.SetActive(true);
            }
            
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

    public void Update()
    {
        waitTime += Time.deltaTime;

        if(waitTime >= 60 && !lightJam.activeSelf)
        {
            stormReady = true;
            lightJam.SetActive(true);
        }
        else if(waitTime < 60)
        {
            stormReady = false;
        }
        
        if (Input.GetKeyDown(KeyCode.E) && ready && stormReady)
        {
            cameraFollow.Shake();
            storming = true;
            waitTime = 0;
            LeverOn.SetActive(true);
            LeverOff.SetActive(false);
            lightJam.SetActive(false);
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/JamLeverOn", gameObject);
        }
        if (storming)
        {
            JamStorm();
        }
    }

    public void JamStorm()
    {
        currentTime += Time.deltaTime;
        stormTime += Time.deltaTime;
        

        
        

        if(currentTime >= 0.2f)
        {
        fishSpawnX = Random.Range(0, 2);
        fishSpawnY = Random.Range(-1.5f, -20);


            if(fishSpawnX == 0)
            {
                
                {
                    Instantiate(Fish5, new Vector3(-26f, fishSpawnY, 0), Quaternion.identity); 
                }
                
            }
            else if(fishSpawnX != 0) 
            {
                
                {
                    Instantiate(Fish5, new Vector3(-56f, fishSpawnY, 0), Quaternion.Euler(0, 180, 0)); 
                }
                
            }
            

            currentTime = 0;

            if(stormTime >= 17f)
            {
                stormTime = 0;
                storming = false;
                currentTime = 0;
                waitTime = 0;
                LeverOn.SetActive(false);
                LeverOff.SetActive(true);
                FMODUnity.RuntimeManager.PlayOneShotAttached("event:/JamLeverOff", gameObject);
            }
        }
    }


}

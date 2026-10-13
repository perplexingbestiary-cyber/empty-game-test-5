using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject Fish;
    public GameObject Fish2;
    public GameObject Fish3;
    public GameObject Fish4;
    public GameObject Fish5;
    //public GameObject BigFish;
    public float fishSpawnY;
    public float uncommonFishSpawnY;
    public float rareFishSpawnY;
    public int fishSpawnX;

    

    public int fishID;

    //public bool ready;

    public float currentTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(Fish, new Vector3(-26f, -2f, 0), Quaternion.identity);
        //Instantiate(BigFish, new Vector3(-56f, -21f, 0), Quaternion.Euler(0, 180, 0));
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        

        if(currentTime >= 1.5f)
        {

        fishSpawnX = Random.Range(0, 2);
        fishSpawnY = Random.Range(-1.5f, -10);
        uncommonFishSpawnY = Random.Range(-9, -15);
        rareFishSpawnY = Random.Range(-14f, -20);

        fishID = Random.Range(0, 6);

            if(fishSpawnX == 0)
            {
                if(fishID == 1)
                {
                   Instantiate(Fish, new Vector3(-26f, fishSpawnY, 0), Quaternion.identity); 
                   
                }
                else if(fishID == 2)
                {
                    Instantiate(Fish2, new Vector3(-26f, fishSpawnY, 0), Quaternion.identity); 
                }
                else if(fishID == 3)
                {
                    Instantiate(Fish3, new Vector3(-26f, fishSpawnY, 0), Quaternion.identity); 
                }
                else if(fishID == 4)
                {
                    Instantiate(Fish4, new Vector3(-26f, uncommonFishSpawnY, 0), Quaternion.identity); 
                }
                else if(fishID == 5)
                {
                    Instantiate(Fish5, new Vector3(-26f, rareFishSpawnY, 0), Quaternion.identity); 
                }
                
            }
            else if(fishSpawnX != 0) 
            {
                if(fishID == 1)
                {
                   Instantiate(Fish, new Vector3(-56f, fishSpawnY, 0), Quaternion.Euler(0, 180, 0));
                }
                else if(fishID == 2)
                {
                    Instantiate(Fish2, new Vector3(-56f, fishSpawnY, 0), Quaternion.Euler(0, 180, 0));
                }
                else if(fishID == 3)
                {
                    Instantiate(Fish3, new Vector3(-56f, fishSpawnY, 0), Quaternion.Euler(0, 180, 0));
                }
                else if(fishID == 4)
                {
                    Instantiate(Fish4, new Vector3(-56f, uncommonFishSpawnY, 0), Quaternion.Euler(0, 180, 0)); 
                }
                else if(fishID == 5)
                {
                    Instantiate(Fish5, new Vector3(-56f, rareFishSpawnY, 0), Quaternion.Euler(0, 180, 0)); 
                }
                
            }
            

            currentTime = 0;
        }


        
    }
}

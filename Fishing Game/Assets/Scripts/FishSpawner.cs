using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject Fish;
    public GameObject Fish2;
    public float fishSpawnY;
    public int fishSpawnX;

    public float currentTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        fishSpawnX = Random.Range(0, 2);
        fishSpawnY = Random.Range(-1.5f, -15);


        if(currentTime >= 2f){
            if(fishSpawnX == 0){
                Instantiate(Fish, new Vector3(-26f, fishSpawnY, 0), Quaternion.identity);
            }
            else if(fishSpawnX != 0){
                Instantiate(Fish, new Vector3(-56f, fishSpawnY, 0), Quaternion.identity);
            }
            currentTime = 0;
        }
    }
}

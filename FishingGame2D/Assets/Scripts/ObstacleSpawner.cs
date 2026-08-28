using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject Barrel;
    public GameObject Crawfish;

    public float barrelSpawnY;
    public int barrelSpawnX;

    public float currentTime1;
    public float currentTime2;

    public float barrelSpawnTime;
    public float crawfishSpawnTime;

    void Start()
    {
        barrelSpawnTime = 8f;
        crawfishSpawnTime = 14f;
    }


    void Update()
    {
        currentTime1 += Time.deltaTime;
        currentTime2 += Time.deltaTime;

        barrelSpawnX = Random.Range(0, 2);
        barrelSpawnY = Random.Range(-1.5f, -15);

        if(currentTime1 >= barrelSpawnTime)
        {
            if(barrelSpawnX == 0)
            {
                Instantiate(Barrel, new Vector3(-26f, barrelSpawnY, 0), Quaternion.identity);
            }
            else if(barrelSpawnX != 0)
            {
                Instantiate(Barrel, new Vector3(-56f, barrelSpawnY, 0), Quaternion.identity);
            }
            currentTime1 = 0;
        }

        if(currentTime2 >= crawfishSpawnTime)
        {
            if(barrelSpawnX == 0)
            {
                Instantiate(Crawfish, new Vector3(-26f, barrelSpawnY, 0), Quaternion.identity);
            }
            else if(barrelSpawnX != 0)
            {
                Instantiate(Crawfish, new Vector3(-56f, barrelSpawnY, 0), Quaternion.identity);
            }
            currentTime2 = 0;
        }
    }
}

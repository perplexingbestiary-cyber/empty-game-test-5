using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject Barrel;
    public float barrelSpawnY;
    public int barrelSpawnX;

    public float currentTime;


    void Update()
    {
        currentTime += Time.deltaTime;

        barrelSpawnX = Random.Range(0, 2);
        barrelSpawnY = Random.Range(-1.5f, -15);

        if(currentTime >= 8f){
            if(barrelSpawnX == 0)
            {
                Instantiate(Barrel, new Vector3(-26f, barrelSpawnY, 0), Quaternion.identity);
            }
            else if(barrelSpawnX != 0)
            {
                Instantiate(Barrel, new Vector3(-56f, barrelSpawnY, 0), Quaternion.identity);
            }
            currentTime = 0;
        }
    }
}

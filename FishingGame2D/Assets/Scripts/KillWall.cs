using UnityEngine;

public class KillWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Fish")){
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Barrel")){
            Destroy(other.gameObject);
        }
        //Debug.Log("entered kill collider");
    }
}

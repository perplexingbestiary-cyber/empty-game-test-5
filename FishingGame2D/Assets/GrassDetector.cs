using UnityEngine;
using TarodevController;

public class GrassDetector : MonoBehaviour
{
    public PlayerController playerController;
    

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerController.GrassFootsteps();
        }
    }
}

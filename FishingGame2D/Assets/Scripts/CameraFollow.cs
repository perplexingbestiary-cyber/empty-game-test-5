using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform target1;      // The player object
    public Transform target2; //lure
    public Vector3 offset = new Vector3(0, 2, -10); // Camera offset
    public float smoothTime = 0.3f; // Time to reach target (lower = snappier)

    public bool player;
    public bool lure;

    public float duration;

    private Vector3 velocity = Vector3.zero;

    void Start(){
        player = true;
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = 60;
    }

    void LateUpdate()
    {
        if(player)
        {
        Vector3 desiredPosition = target1.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        }

        else if(lure)
        {
            Vector3 desiredPosition = target2.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        }
        
    }

    public void FollowPlayer()
    {
        player = true;
        lure = false;
    }

    public void FollowLure()
    {
        lure = true;
        player = false;
    }

     public void Shake()
    {
        StartCoroutine(ShakeRoutine());
    }

    private IEnumerator ShakeRoutine()
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            transform.position = originalPos + Random.insideUnitSphere * 0.1f;
            yield return null;
        }

        transform.position = originalPos;
    }
}

   

    

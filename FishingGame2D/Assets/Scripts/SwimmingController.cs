using UnityEngine;

public class SwimmingController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = 60;

    }

    void Update()
    {
        // Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        // Rotate character based on input direction
        
        
    }

    void FixedUpdate()
    {
        //rb.MovePosition() = movement * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement != Vector2.zero)
        {
            // Calculate angle from movement vector
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            
            // Smoothly rotate or snap to direction
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.fixedDeltaTime);
        }
    }
}

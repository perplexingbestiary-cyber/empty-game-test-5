using UnityEngine;

public class LineMovement : MonoBehaviour
{
    public float speed = 1f;
    public float scaling;
    public LureMovement lureMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime); 

        if(transform.position.y > 0.6f)
        {
            transform.position = new Vector3(-41f, 0.6f, 0.1f);
        }

        transform.localScale = new Vector3(0.1f, -scaling*(transform.position.y - 0.6f), 0.1f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Crawfish"))
        {
            transform.position = new Vector3(-41f, 0.6f, 0.1f);
            lureMovement.ResetLure();
        }
    }

    public void ResetLine()
    {
        transform.position = new Vector3(-41f, 0.6f, 0.1f);
        transform.localScale = new Vector3(0.1f, -scaling*(transform.position.y - 0.6f), 0.1f);
    }
}

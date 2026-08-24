using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed;
    public bool right;
    //public Transform lure;
    public bool caught;
    public bool landed;
    private GameObject lure;
    private Rigidbody2D rb;
    public CapsuleCollider2D Collider;
    public LureMovement lureScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(transform.position.x >= -26f){
            right = true;
        }
        else{
            right = false;
        }

        lure = GameObject.Find("Lure");
        lureScript = lure.GetComponent<LureMovement>();

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!caught)
        {
            if(!right)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.right, Time.deltaTime * (speed + Random.Range(0f, 0.2f))); 

            }
            else if(right)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + -transform.right, Time.deltaTime * (speed + Random.Range(0f, 0.2f))); 

            }
        }
        else
        {
            

            if(transform.position.y >= 0.5f && !landed)
            {
                transform.position = new Vector3(-37f, 3f, 0f);
                rb.gravityScale = 1f;
                landed = true;
                Collider.enabled = true;

                lureScript.Empty();
            }
            else if (!landed)
            {
            transform.position = lure.transform.position;
            transform.rotation = Quaternion.Euler(0, 0, 90); 

            lureScript.Full();
            }
            


        }
        
    }

    public void KillFish()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        caught = true;

        if (other.gameObject.CompareTag("Barrel"))
        {
            KillFish();

            if (caught)
            {
                //landed = true;
                lureScript.Empty();
            }
        }
    }
}

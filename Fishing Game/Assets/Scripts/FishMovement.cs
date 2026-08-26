using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public float speed;
    public bool right;
    //public Transform lure;
    public bool caught;
    public bool landed;
    public bool destroyed;
    public bool night;

    private GameObject lure;
    private Rigidbody2D rb;
    public CapsuleCollider2D Collider;
    public LureMovement lureScript;

    public GameObject shopItem;

    private InventoryController inventoryController;

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
        inventoryController = FindAnyObjectByType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(landed && !destroyed && night)
        {
            destroyed = true;
            //night = false;
            Destroy(gameObject);
        }

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
/*
                Item item = GetComponent<Item>();
                if(item != null)
                {
                */
                    bool itemAdded = inventoryController.AddItem(shopItem);

                    if (itemAdded)
                    {
                        //Destroy(gameObject);
                    }
                
                
            }
            else if (!landed)
            {
                if(lure != null)
                {
                    transform.position = lure.transform.position;
                }
                
                transform.rotation = Quaternion.Euler(0, 0, 90); 

                lureScript.Full();
            }
            


        }
        
    }

    public void KillFish()
    {
        Destroy(gameObject);
    }

    public void Night()
    {
        night = true;
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

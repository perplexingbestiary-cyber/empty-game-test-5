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
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D Collider;
    public BoxCollider2D boxCollider;
    public LureMovement lureScript;

    public bool facingRight;

    //public float moveX;

    public GameObject shopItem;
    //public GameObject Fish;

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
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventoryController = FindAnyObjectByType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (caught && !boxCollider.enabled && !landed)
        {
            boxCollider.enabled = true;
        }

        if(landed && boxCollider.enabled)
        {
            boxCollider.enabled = false;
        }


        if(landed && !destroyed && night)
        {
            destroyed = true;
            //night = false;
            //Destroy(Fish);
            Destroy(gameObject);
        }

        if(!caught)
        {

            transform.position = Vector3.MoveTowards(transform.position, transform.position + -transform.right, Time.deltaTime * (speed + Random.Range(0f, 0.5f)));             
        }

        else if(caught)
        {
            
            //boxCollider.enabled = true;
            if(transform.position.y >= 0.5f && !landed)

            {
                //boxCollider.enabled = false;
                transform.position = new Vector3(-37f, 3f, 0f);
                rb.gravityScale = 1f;
                landed = true;
                Collider.enabled = true;

                lureScript.Empty();
                Invoke(nameof(KillFish), 10);
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
                
                transform.rotation = Quaternion.Euler(0, 0, -90); 

                lureScript.Full();
            }
            


        }
        
    }

    public void KillFish()
    {
        //Destroy(Fish);
        Destroy(gameObject);
    }

    public void Night()
    {
        night = true;
    }

    public void FlipSprite()
    {

        //spriteRenderer.flipX = !facingRight;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Lure"))
        {
            caught = true;
        }
        

        if (other.gameObject.CompareTag("Barrel"))
        {
            KillFish();

            if (caught)
            {
                //landed = true;
                lureScript.Empty();
            }
        }

        if (other.gameObject.CompareTag("Crawfish"))
        {
            KillFish();
            //Debug.Log("line cut");
            if(caught)
            {
                
                lureScript.Empty();
                lureScript.LineCut();
            }
        }
    }
}

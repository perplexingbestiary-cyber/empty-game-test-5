using UnityEngine;

public class FishBigMovement : MonoBehaviour
{
    public float speed;
    public bool right;
    //public Transform lure;
    public bool caught;
    public bool landed;
    public bool destroyed;
    public bool night;

    public bool bigFishLeft;
    public float bigFishTime;

    private GameObject lure;
    
    public BoxCollider2D lineCollider;

    private Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D Collider;
    public BoxCollider2D boxCollider;

    public LureMovement lureScript;
    //private GameObject cameraFollow;
    public CameraFollow cameraFollowScript;

    public bool facingRight;

    //public float moveX;

    public GameObject shopItem;

    //public GameObject Fish;
    public GameObject FishGame;

    private InventoryController inventoryController;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bigFishLeft = true;
        if(transform.position.x >= -26f){
            right = true;
        }
        else{
            right = false;
        }

        lure = GameObject.Find("Lure");
        //cameraFollow = GameObject.Find("Main Camera");
        //FishGame = GameObject.Find("FishGame ");

        lureScript = lure.GetComponent<LureMovement>();
        //cameraFollowScript = cameraFollow.GetComponent<CameraFollow>();
        

        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        inventoryController = FindAnyObjectByType<InventoryController>();
    }

    // Update is called once per frame
    void Update()
    {
        bigFishTime += Time.deltaTime;

        if(bigFishTime >= 80f)
        {
            if (bigFishLeft)
            {
                transform.position = new Vector3(-70f, -21f, 0);
                transform.eulerAngles = new Vector3(0, 180, 0);

                bigFishLeft = false;

                bigFishTime = 0f;
            }
            else
            {
                transform.position = new Vector3(-10f, -21f, 0);
                transform.eulerAngles = new Vector3(0, 0, 0); 
                bigFishLeft = true;

                bigFishTime = 0f;
            }
        }

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
            lineCollider.enabled = false;
            //Debug.Log(transform.position.y);
            //boxCollider.enabled = true;
            /*
            if(transform.position.y >= 0.5f && !landed)
            {
                //
                //Debug.Log("did it");
                
                //boxCollider.enabled = false;
                transform.position = new Vector3(-37f, 3f, 0f);
                rb.gravityScale = 1f;
                landed = true;
                Collider.enabled = true;

                lureScript.Empty();
                Invoke(nameof(KillFish), 10);

                Item item = GetComponent<Item>();
                if(item != null)
                {
                
                    bool itemAdded = inventoryController.AddItem(shopItem);

                    if (itemAdded)
                    {
                        //Destroy(gameObject);
                    }
                
                
                }
            }
            */
            /*else*/if (!landed)
            {
                if(lure != null)
                {
                    transform.position = lure.transform.position;
                }
                cameraFollowScript.FollowPlayer();
                FishGame.SetActive(true);
                
               // transform.rotation = Quaternion.Euler(0, 0, -90); 

                lureScript.Full();
            }
    }   


    }
        
    

    public void KillFish()
    {
        //Destroy(Fish);
        Destroy(gameObject);
        Debug.Log("Kill big fish");
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
        if (other.gameObject.CompareTag("SpecLure"))
        {
            caught = true;
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Catch", gameObject);
        }
        
/*
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
        */
    }
    public void LostFish()
    {
        cameraFollowScript.FollowLure();
        caught = false;
        lureScript.Empty();
        lureScript.line -= 1;
        lureScript.ResetLure();
        lineCollider.enabled = true;
        //lureScript.ResetLure();

            if (bigFishLeft)
            {
                transform.position = new Vector3(-70f, -21f, 0);
                transform.eulerAngles = new Vector3(0, 180, 0);

                bigFishLeft = false;

                bigFishTime = 0f;
            }
            else
            {
                transform.position = new Vector3(-10f, -21f, 0);
                transform.eulerAngles = new Vector3(0, 0, 0); 
                bigFishLeft = true;

                bigFishTime = 0f;
            }

            Debug.Log("reset");
    }
}


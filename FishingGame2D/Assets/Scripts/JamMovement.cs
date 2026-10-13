using JetBrains.Annotations;
using UnityEngine;

public class JamMovement : MonoBehaviour
{
    public float speed;
    public bool right;
    //public Transform lure;
    public bool caught;
    public bool landed;
    public bool destroyed;
    public bool night;

    public string Catch;

    private GameObject lure;
    private Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D Collider;
    public BoxCollider2D boxCollider;
    public LureMovement lureScript;

    public bool facingRight;

    //public float moveX;

    //public GameObject shopItem;
    //public Item item;
    //public GameObject Fish;

    private InventoryController inventoryController;
    private RequestController requestController;
    private CameraFollow cameraFollow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = 60;
        
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
        requestController = FindAnyObjectByType<RequestController>();
        cameraFollow = FindAnyObjectByType<CameraFollow>();

        
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
            //the following is for when the fish is caught and landed
            if(transform.position.y >= 0.5f && !landed)
            {
                
                //KillFish();
                //the following is only used when you want the fish to fall to the ground

                transform.position = new Vector3(-37f, 3f, 0f);
                rb.gravityScale = 1f;
                landed = true;
                requestController.FishJam();
                Collider.enabled = true;
                
                
                lureScript.Empty();
                Invoke(nameof(KillFish), 10);
                
                
/*
                Item item = GetComponent<Item>();
                if(item != null)
                {
                */
                requestController.JamCaught();
                
                
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
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Catch", gameObject);
            cameraFollow.Shake();

        }
    
    }
}


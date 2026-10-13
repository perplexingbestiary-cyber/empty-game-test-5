//using NUnit.Framework;
//using NUnit.Framework.Constraints;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class LureMovement : MonoBehaviour
{
    public float speed;
    public bool empty; 
    public bool stop;
    public BoxCollider2D boxCollider1;
    public BoxCollider2D boxCollider2;

    public int line;
    public int specLure;

    public float lineLength;
    public bool hasLine = true;
    public bool hasLure = false;

    public string Reel;
    public float value;
    public float velocity;
    private Vector3 prevPosition;

    

    private Rigidbody2D rigidbody;

    public FishingDetector fishingDetector;
    public LineMovement lineMovement;
    public GameObject reel;
    public BobberAudio bobberAudio;

    public Light2D light;

    


    FMOD.Studio.EventInstance Event1;
    // Update is called once per frame

    void Start()
    {
        lineLength = 10f;
        empty = true;
        stop = true;
        line = 3;

        Event1 = FMODUnity.RuntimeManager.CreateInstance(Reel);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Event1, reel, GetComponent<Rigidbody>());
        Event1.start();    
        Event1.release();

        rigidbody = GetComponent<Rigidbody2D>();
        prevPosition = transform.position;
        
    }

    
    void Update() 
    {
        

        //Debug.Log(rigidbody.linearVelocity);
        

        if(line > 0 && !hasLine)
        {
            fishingDetector.YesLine();
            hasLine = true;
        }

        if(line <= 0 && hasLine)
        {
            fishingDetector.NoLine();
            hasLine = false;
        }
        if(specLure > 0 && !hasLure)
        {
            fishingDetector.YesSpecLure();
            hasLure = true;
        }
        else if(specLure <= 0 && hasLure)
        {
            fishingDetector.NoSpecLure();
            hasLure = false;
            
        }
        if (!stop)
        {
        float moveX = 0f;
        float moveY = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, prevPosition);
        velocity = distance / Time.deltaTime;
        prevPosition = transform.position;

        //if(transform.position.y < -8)
            {
                light.intensity = 1 + transform.position.y / 40;
            }
          //  else
            {
          //      light.intensity = 1 + transform.position.y / 70;
            }
        

        

        if(transform.position.y > 0.6f)
        {
            transform.position = new Vector3(-41f, 0.6f, 0f);
        }

        if(transform.position.y < -lineLength)
        {
            transform.position = new Vector3(-41f,-lineLength, 0f);
        }

        }
        
        if (empty && !boxCollider1.enabled)
        {
            boxCollider1.enabled = true;
            boxCollider2.enabled = true;
        }
        else if(!empty && boxCollider1.enabled)
        {
            boxCollider1.enabled = false;
            boxCollider2.enabled = false;
        }

        ReelAudio();
    }

    public void ResetLure()
    {
        transform.position = new Vector3(-41f, 0.6f, 0f);
        lineMovement.ResetLine();
        
    }

    public void Stop()
    {
        stop = true;
        velocity = 0;
    }

    public void Go()
    {
        stop = false;
    }

    public void Full()
    {
        empty = false;
        bobberAudio.Fish();
    }
    public void Empty()
    {
        empty = true;
        bobberAudio.NoFish();

        if (hasLure)
        {
            LureLost();
        }
        
    }

    public void LineCut()
    {
        line -= 1;

        if (hasLure)
        {
          LureLost();  
        }
    }

    public void LureLost()
    {
        specLure -= 1;
    }

    public void ReelAudio()
    {
        
            value = velocity / 8;
            Event1.setParameterByName("Reel", value);

    }

}

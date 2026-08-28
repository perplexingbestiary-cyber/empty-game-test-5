using NUnit.Framework.Constraints;
using UnityEngine;

public class LureMovement : MonoBehaviour
{
    public float speed;
    public bool empty;
    public bool stop;
    public BoxCollider2D boxCollider1;
    public BoxCollider2D boxCollider2;
    public int line;
    public float lineLength;
    public bool hasLine = true;


    public FishingDetector fishingDetector;
    // Update is called once per frame

    void Start()
    {
        lineLength = 10f;
        empty = true;
        line = 3;
    }

    
    void Update() 
    {
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
        if (!stop)
        {
        float moveX = 0f;
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime); 

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
    }

    public void ResetLure()
    {
        transform.position = new Vector3(-41f, 0.6f, 0f);
    }

    public void Stop()
    {
        stop = true;
    }

    public void Go()
    {
        stop = false;
    }

    public void Full()
    {
        empty = false;
    }
    public void Empty()
    {
        empty = true;
    }

    public void LineCut()
    {
        line -= 1;
    }

}

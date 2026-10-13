using UnityEngine;

public class CrawfishMovement : MonoBehaviour
{
    public float speed;
    public bool right;

    void Start()
    {
        if(transform.position.x >= -26f)
        {
            right = true;
        }
        else
        {
            right = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
            if(!right)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + -transform.right, speed * Time.deltaTime); 

            }
            else if(right)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + -transform.right, speed * Time.deltaTime); 

            }
    }
}


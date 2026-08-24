using NUnit.Framework.Constraints;
using UnityEngine;

public class LureMovement : MonoBehaviour
{
    public float speed;
    public bool empty;
    public BoxCollider2D boxCollider1;
    public BoxCollider2D boxCollider2;
    // Update is called once per frame

    void Start()
    {
        empty = true;
    }
    void Update() 
    {
        float moveX = 0f;
        float moveY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime); 

        if(transform.position.y > 0.6f)
        {
            transform.position = new Vector3(-41f, 0.6f, 0f);
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

    public void Full()
    {
        empty = false;
    }
    public void Empty()
    {
        empty = true;
    }

}

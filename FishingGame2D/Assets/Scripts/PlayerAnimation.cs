using UnityEngine;

namespace TarodevController
{
    public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;

    public bool left;
    private IPlayerController _player;
    [SerializeField] private SpriteRenderer _sprite;
    public Rigidbody2D rigidbody;
   private Vector3 previousPosition;

    void FixedUpdate() 
    {
        /*
        Debug.Log(Mathf.Approximately(rigidbody.linearVelocity.magnitude, 0f));
        if(Mathf.Approximately(rigidbody.linearVelocity.magnitude, 0f))
            {
                anim.SetBool("Walking", true);
            }
            else
            {
                anim.SetBool("Walking", false);
                
               // Debug.Log("not walking");

            }
*/
            if ((previousPosition.x - transform.position.x) > 0.1) 
            {
                
                left = true;
                Flip();
              //  Debug.Log("walking left");
                
            }
            else if((transform.position.x - previousPosition.x) > 0.1)
            {
                
                left = false;
                Flip();
               // Debug.Log("walking right");
            }
            
           
    previousPosition = transform.position;
}

void Flip() 
{
            if (left)
            {
                Vector3 theScale = transform.localScale;
                theScale.x = -1;
                transform.localScale = theScale;

       
                
            }
            else
            {
                Vector3 theScale = transform.localScale;
                theScale.x = 1;
                transform.localScale = theScale;

        
                
            }
    
}
}
}



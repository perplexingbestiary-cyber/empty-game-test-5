using UnityEngine;

public class LureMovement : MonoBehaviour
{
    public float speed;
    // Update is called once per frame
   void Update() {
    float moveX = 0f;//0.1f;//Input.GetAxis("Horizontal");
    float moveY = Input.GetAxis("Vertical");
    transform.Translate(new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime);
}

public void ResetLure(){
    transform.position = new Vector3(-41f, -0.1f, 0f);
}
}

using UnityEngine;

public class JamAnimation : MonoBehaviour
{
     public Animator animator;

     public void Jam()
    {
        animator.SetTrigger("Jam");
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/JamCollect", gameObject);
    }
}

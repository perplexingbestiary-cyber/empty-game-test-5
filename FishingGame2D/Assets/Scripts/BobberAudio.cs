using UnityEngine;

public class BobberAudio : MonoBehaviour
{
    public string BobberSink;
    public string BobberEmerge;
    public string FishEmerge;

    

    public bool fish;

    public Ambience ambience;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LureAudio"))
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached(BobberSink, gameObject);
            ambience.WaterEnter(); 
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LureAudio"))
        {
            if (fish)
            {
                FMODUnity.RuntimeManager.PlayOneShotAttached(FishEmerge, gameObject); 
                fish = false;
            }
            else
            {
                FMODUnity.RuntimeManager.PlayOneShotAttached(BobberEmerge, gameObject);
                fish = false; 
            }
            ambience.WaterExit();
        }
        
    }

    public void Fish()
    {
        fish = true;
    }
    public void NoFish()
    {
        fish = false;
    }
}

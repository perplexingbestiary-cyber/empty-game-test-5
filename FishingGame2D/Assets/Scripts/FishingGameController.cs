
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FishingGameController : MonoBehaviour
{
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;
    [SerializeField] Transform fish;

    float fishPosition;
    float fishDestination;

    public string scene;
    public string CutLine;

    float fishTimer;

    [SerializeField] float timerMultiplicator = 3f;
    float fishSpeed;

    [SerializeField] float smoothMotion = 1f;

    public Transform hook;
    //float hookPosition;
    //public float hookSize = 0.1f;
    //public float hookPower = 0.5f;

    //float hookProgress;
    //float hookPullVelocity;

    public float hookPullPower = 1.5f;
    //public float hookGravityPower = 0.005f;
    //public float hookProgressDegradationPower = 0.1f;

    public float progress = 10f;

    public bool lost;

    public Rigidbody2D rb;

    public FishBigMovement fishBigMovement;
    public Ambience ambience;
    public GameObject FishGame;


    void Start()
    {
        QualitySettings.vSyncCount = 0; // Set vSyncCount to 0 so that using .targetFrameRate is enabled.
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Fish();
        Hook();
        Debug.Log(Vector3.Distance(hook.position, fish.position));
        //Debug.Log(Vector3.Distance(hook.position, fish.position));
        if(Vector3.Distance(hook.position, fish.position) <= 0.2f)
        {
            progress += 1f * Time.deltaTime;
        }
        
        else
        {
            progress -= 2f* Time.deltaTime;
        }

        if (!lost)
        {
            if (progress <= 0f)
            {
            lost = true;
            Debug.Log("you lost the fish");
            FMODUnity.RuntimeManager.PlayOneShotAttached(CutLine, gameObject);
            fishBigMovement.LostFish();

            FishGame.SetActive(false);
            }
            /*
            else if(progress >= 15f)
            {
                Debug.Log("you caught the fish");
                ambience.Stop();
                SceneManager.LoadScene(scene);
            }
            */
        }
        

    }

    public void Hook()
    {
        /*
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;
        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1 - hookSize / 2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);
        */
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/FishGameClick", gameObject);
            rb.linearVelocity = Vector2.up * hookPullPower;
        }

    }

    public void Fish()
    {
        fishTimer -= Time.deltaTime;
        if(fishTimer < 0f)
        {
            fishTimer = Random.Range(0f, 1f) * timerMultiplicator;

            fishDestination = Random.Range(0f, 1f);
        }

        fishPosition = Mathf.SmoothDamp(fishPosition, fishDestination, ref fishSpeed, smoothMotion);
        fish.position = Vector3.Lerp(bottomPivot.position, topPivot.position, fishPosition);
    }
}

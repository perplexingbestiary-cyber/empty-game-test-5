using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class ButtonController : MonoBehaviour
{
[SerializeField] private Button button;
public GameObject currentPage;
public GameObject targetPage;
public GameObject targetPage2;

bool audioResumed = false;

public string scene; 

//[Header("FMOD Settings")]
//private static FMOD.Studio.EventInstance Keyboard;
public void ResumeAudio()
    {
        if (!audioResumed)
        {
            var result = FMODUnity.RuntimeManager.CoreSystem.mixerSuspend();
            Debug.Log(result);
            result = FMODUnity.RuntimeManager.CoreSystem.mixerResume();
            Debug.Log(result);
            audioResumed = true;
        }
    }

private void Awake()
    {
        button.onClick.AddListener(() =>
        {
            

            ResumeAudio();
            //FMOD.Studio.EventInstance Keyboard = FMODUnity.RuntimeManager.CreateInstance("event:/Keyboard");        // If they are, we create an FMOD event instance. We use the event path inside the 'FootstepsEventPath' variable to find the event we want to play.
            //Keyboard.start();                                                                                        // We then play a footstep!.
            //Keyboard.release();

            
            currentPage.SetActive(false);
            //targetPage.SetActive(true);
            //targetPage2.SetActive(true);
            //SceneManager.LoadScene(scene);
        });

       
    }

}


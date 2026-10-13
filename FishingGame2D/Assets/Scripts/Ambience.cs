using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class Ambience : MonoBehaviour
{
    public string Waves;
    public string Music;

    public float t;
    public bool under;
    public float value;
    public Button button;


    FMOD.Studio.EventInstance Event1;
    FMOD.Studio.EventInstance Event2;

    public GameObject ocean;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
/*
        Event1 = FMODUnity.RuntimeManager.CreateInstance(Waves);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Event1, ocean, GetComponent<Rigidbody>());
        Event1.start();    
        Event1.release(); 

        Event2 = FMODUnity.RuntimeManager.CreateInstance(Music);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Event2, ocean, GetComponent<Rigidbody>());
        Event2.start();    
        Event2.release(); 
        //FMODUnity.RuntimeManager.PlayOneShotAttached(FMODEventPath, gameObject);
        */
    }
    void Awake()
    {
        button.onClick.AddListener(() =>
        {
            Event1 = FMODUnity.RuntimeManager.CreateInstance(Waves);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Event1, ocean, GetComponent<Rigidbody>());
        Event1.start();    
        Event1.release(); 

        Event2 = FMODUnity.RuntimeManager.CreateInstance(Music);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Event2, ocean, GetComponent<Rigidbody>());
        Event2.start();    
        Event2.release(); 
        //FMODUnity.RuntimeManager.PlayOneShotAttached(FMODEventPath, gameObject);

            
        });
    }
    public void Stop()
    {
        
        Event1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        Event2.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);

         
        
    }
    public void Update()
    {
        if (under)
        {
            Underwater();
        }
        else
        {
            Outwater();
        }
    }
        public void Underwater()
    {
        if (value < 1)
        {
            value = Mathf.Lerp(0f, 1, t);
            
            
            t += 2f * Time.deltaTime;
            Event1.setParameterByName("Underwater", value);
            Event2.setParameterByName("Underwater", value);
            if(value == 1)
            {
               // under = false;
                t = 0;
            } 
        }
    }
        public void Outwater()
    {
        if (value > 0)
        {
            value = Mathf.Lerp(1f, 0, t);
            
            
            t += 2f * Time.deltaTime;
            Event1.setParameterByName("Underwater", value);
            Event2.setParameterByName("Underwater", value);
            if(value == 0)
            {
              //  under = false;
                t = 0;
            } 
        }
    }

    public void WaterEnter()
    {
        under = true;
    }
    public void WaterExit()
    {
        under = false;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMOD.Studio;

public class FMODStateProgression : MonoBehaviour
{
    private FMOD.Studio.EventInstance instance;

    [FMODUnity.EventRef]
    public string fmodEvent;

    public FMODUnity.StudioEventEmitter Emitter;

    int currentMusicState = -1;

    // Start is called before the first frame update
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
        instance.start();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMusicState == GlobalState.CurrentState)
        {
            return;
        }

        if (GlobalState.CurrentState == 0)
        {
            instance.setParameterByName("Progression", 0);
            UnityEngine.Debug.Log("New music state 0");
        }
        if (GlobalState.CurrentState == 1)
        {
            instance.setParameterByName("Progression", 1);
            UnityEngine.Debug.Log("New music state 1");
        }
        if (GlobalState.CurrentState == 2)
        {
            instance.setParameterByName("Progression", 2);
            UnityEngine.Debug.Log("New music state 2");
        }
        if (GlobalState.CurrentState == 3)
        {
            instance.setParameterByName("Progression", 3);
            UnityEngine.Debug.Log("New music state 3");
        }
        if (GlobalState.CurrentState == 5)
        {
            instance.setParameterByName("Progression", 4);
            UnityEngine.Debug.Log("New music state 4");
        }

        currentMusicState = GlobalState.CurrentState;

    }
}

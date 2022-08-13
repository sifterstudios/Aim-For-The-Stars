using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnEnter : MonoBehaviour
{
    bool started = false;
    public AudioSource Audio;
    public int ActivateAfterState = 0;
    public int StateToSet = -1;

    void OnTriggerEnter(Collider other)
    {
        if (GlobalState.CurrentState < ActivateAfterState) return;

        if (started == false)
        {
            started = true;
            if (Audio) Audio.Play();

            if (StateToSet != -1)
            {
                GlobalState.CurrentState = StateToSet;
                Debug.Log("New global state: " + GlobalState.CurrentState);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class FlashbackScript : MonoBehaviour
{
    public CharacterController controller;
    public AudioSource Audio;
    public Volume Volume;

    public int ActivateAfterState = 0;
    public int StateToSet = -1;

    float weight = 0.0f;
    bool startWeighting = false;
    bool finished = false;
    bool started = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!started || finished) return;

        if (started)
        {
            if (Audio.isPlaying == false)
            {
                //                Debug.Log("FlashbackScript enabling controller");

                controller.enabled = true;

                weight -= Time.deltaTime;
                if (weight < 0.0f)
                {
                    weight = 0.0f;
                }

                //                Debug.Log("downing " + weight);

                if (weight == 0)
                {
                    finished = true;
                    if (StateToSet != -1)
                    {
                        GlobalState.CurrentState = StateToSet;
                        Debug.Log("New global state: " + GlobalState.CurrentState);
                    }
                }
                Volume.weight = weight;

                startWeighting = false;
            }

            if (startWeighting)
            {
                weight += Time.deltaTime;
                if (weight > 1.0f)
                {
                    weight = 1.0f;
                }
                //                Debug.Log("upping " + weight);

                Volume.weight = weight;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GlobalState.CurrentState < ActivateAfterState) return;

        if (started == false)
        {
            //            Debug.Log("Flashback");

            started = true;
            startWeighting = true;

            //            Debug.Log("FlashbackScript disabling controller");

            controller.enabled = false;
            Audio.Play();
        }
    }
}

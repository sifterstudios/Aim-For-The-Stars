using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtAudio : MonoBehaviour
{
    public AudioSource Audio;
    public int ActivateAfterState = 0;
    public int StateToSet = -1;

    GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (GlobalState.CurrentState < ActivateAfterState) return;

        float distance = 3.0f;

        if (!mainCamera) return;

        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (GameObject.ReferenceEquals(hit.collider.gameObject, gameObject))
                {
                    if (Audio && !Audio.isPlaying)
                    {
                        Audio.Play(0);

                        if (StateToSet != -1)
                        {
                            GlobalState.CurrentState = StateToSet;
                            Debug.Log("New global state: " + GlobalState.CurrentState);
                        }
                    }
                }
            }
        }
    }
}

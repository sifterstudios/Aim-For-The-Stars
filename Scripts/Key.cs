using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public AudioSource Audio;

    GameObject mainCamera;

    bool finished = false;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        float distance = 3.0f;

        if (!mainCamera) return;
        if (finished) return;

        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (GameObject.ReferenceEquals(hit.collider.gameObject, gameObject))
                {
                    finished = true;
                    GetComponent<Renderer>().enabled = false;
                    if (Audio) Audio.Play();
                    GlobalState.CurrentState = 3;
                    Debug.Log("New global state: " + GlobalState.CurrentState);
                }
            }
        }
    }
}

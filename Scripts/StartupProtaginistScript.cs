using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartupProtaginistScript : MonoBehaviour
{
    public CharacterController controller;
    public AudioSource Audio;

    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        controller.enabled = false;
        Audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Audio.isPlaying == false && finished == false)
        {
            controller.enabled = true;
            finished = true;
        }
    }
}

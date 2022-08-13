
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtImage : MonoBehaviour
{
    public Sprite Sprite;
    public AudioSource Audio;
    public AudioSource AfterAudio;

    GameObject mainCamera;

    Canvas canvas;
    Image image;

    bool showingImage;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        GameObject canvasGO = GameObject.FindGameObjectWithTag("MainCanvas");
        if (canvasGO)
        {
            canvas = canvasGO.GetComponent<Canvas>();
            if (canvas)
            {
                GameObject imageGO = GameObject.Find("Image");
                if (imageGO)
                {
                    image = imageGO.GetComponent<Image>();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = 3.0f;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (showingImage)
            {
                showingImage = false;
                image.sprite = Sprite;
                image.enabled = false;
                if (Audio) Audio.Stop();
                if (AfterAudio) AfterAudio.Play();
                return;
            }
        }

        if (!mainCamera) return;

        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //                Debug.Log("Hit Image: " + hit.collider.gameObject.GetInstanceID() + gameObject.GetInstanceID());
                if (GameObject.ReferenceEquals(hit.collider.gameObject, gameObject))
                {
                    if (image)
                    {
                        showingImage = true;
                        image.sprite = Sprite;
                        image.enabled = true;
                        if (Audio) Audio.Play();
                    }
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Material material;
    AudioSource audioData;

    public float OpeningSpeed = 1.0f;
    public Collider Collider;
    public bool IsOpenable = true;

    static float maxSmoothness = 1.0f;
    static float minSmoothness = 0.4f;

    bool opening;
    float smoothness;

    // Start is called before the first frame update
    void Start()
    {
        smoothness = minSmoothness;

        material = GetComponent<Renderer>().material;
        material.SetFloat("_Smoothness", smoothness);

        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            if (smoothness == minSmoothness)
            {
                audioData.Play(0);
            }
            if (smoothness < maxSmoothness)
            {
                smoothness += Time.deltaTime * OpeningSpeed;
                if (smoothness > maxSmoothness / 2)
                {
                    if (Collider) Collider.enabled = false;
                }

                if (smoothness > maxSmoothness)
                {
                    smoothness = maxSmoothness;
                }
                material.SetFloat("_Smoothness", smoothness);
            }
        }

        if (!opening && smoothness > minSmoothness)
        {
            if (Collider) Collider.enabled = true;
            smoothness -= Time.deltaTime * OpeningSpeed;

            if (smoothness < minSmoothness)
            {
                smoothness = minSmoothness;
            }
            material.SetFloat("_Smoothness", smoothness);
        }
    }

    public void Open()
    {
        opening = true;
    }

    public void Close()
    {
        opening = false;
    }
}

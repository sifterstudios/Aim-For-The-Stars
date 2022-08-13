using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtHideGameObject : MonoBehaviour
{
    public GameObject GameObjectToDeactivate;

    GameObject mainCamera;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        float distance = 3.0f;

        if (!mainCamera) return;

        RaycastHit hit;
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (GameObject.ReferenceEquals(hit.collider.gameObject, gameObject))
                {
                    GameObjectToDeactivate.SetActive(false);
                }
            }
        }
    }
}

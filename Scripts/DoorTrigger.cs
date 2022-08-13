using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider col)
    {
        if (door)
        {
            door.Open();
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (door)
        {
            door.Close();
        }
    }
}

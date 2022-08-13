using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableByState : MonoBehaviour
{
    public int ActivateAfterState = 0;

    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalState.CurrentState < ActivateAfterState) return;
        if (finished) return;

        GetComponent<Renderer>().enabled = true;
        finished = true;
    }
}

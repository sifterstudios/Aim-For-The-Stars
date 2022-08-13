using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAtEndGame : MonoBehaviour
{
    public RectTransform Panel;
    public int ActivateAfterState = 0;

    bool started = false;
    bool finished = false;

    void Start()
    {
    }

    void Update()
    {
        if (GlobalState.CurrentState < ActivateAfterState) return;

        if (finished) return;

        if (Panel) Panel.transform.gameObject.SetActive(true);
        finished = true;
    }
}

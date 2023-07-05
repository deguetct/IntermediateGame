using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class LogTest : MonoBehaviour
{


    void Start()
    {
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        playerMovement.OnPressF += OnPressF_Action;

    }
    public void OnPressF_Action(object sender, EventArgs f)
    {
        Debug.Log("Yes times 2");
    }

    void Update()
    {

    }
    public void OnPressE()
    {
        Debug.Log("Yes");
    }

}

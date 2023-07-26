using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;


public class coolThing : MonoBehaviour
{

    public float timers = 0;

    [SerializeField] private GameObject buttonOne;
    [SerializeField] private GameObject buttonTwo;
    [SerializeField] private GameObject scary;
    // Start is called before the first frame update
    void Start()
    {
        scary.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (timers > 0)
        {
            timers -= Time.deltaTime;
            buttonTwo.SetActive(false);
            scary.SetActive(true);
            Debug.Log(timers);
        }
        else
        {
            buttonTwo.SetActive(true);
            scary.SetActive(false);
        }
    }

    public void remove()
    {
        buttonOne.SetActive(false);
    }

    public void shockAndHorror()
    {
        timers = 0.5f;

    }
}

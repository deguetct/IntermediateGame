using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Text myTest;
    public string test = "nice";
    public float timer = 0;
    public float minuteCount = 0;
    public bool menuUp = false;

    // Start is called before the first frame update
    void Start()
    {
        myTest.text = test;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && menuUp == true)
        {
            menuUp = false;
        }else if(Input.GetKeyUp(KeyCode.Escape) && menuUp == false)
        {
            menuUp = true;
        }

        if (menuUp == false)
        {
            if (timer >= 0)
            {
                timer += Time.deltaTime;
                if (timer < 60 && minuteCount < 1)
                {
                    if (timer < 10)
                    {
                        myTest.text = "0" + timer.ToString("F2");
                    }
                    else
                    {
                        myTest.text = timer.ToString("F2");
                    }

                }
                else if (timer >= 60)
                {
                    timer = timer - 60;
                    minuteCount = minuteCount + 1;
                    myTest.text = minuteCount.ToString("F0") + ":" + timer.ToString("F0");
                }
                else if (minuteCount >= 1)
                {
                    if (timer < 10)
                    {
                        myTest.text = minuteCount.ToString("F0") + ":" + "0" + timer.ToString("F0");
                    }
                    else
                    {
                        myTest.text = minuteCount.ToString("F0") + ":" + timer.ToString("F0");
                    }

                }
            }
        }
    }
}

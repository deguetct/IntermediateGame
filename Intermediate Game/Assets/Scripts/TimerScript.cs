using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public Text myTest;
    public string test = "nice";
    public float timer = 0;
    public float minuteCount = 0;
    public bool menuUp = false;
    public bool gameFinish = false;
    public TMP_Text scoreText;
    public TMP_Text highText;
    public TextAsset textFile;
    public string highScoreText;


    [SerializeField] private BoxCollider2D endLine;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private GameObject end;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameFinish = true;
        endMenu.SetActive(true);

      if (timer < 10)
        {
            scoreText.text = minuteCount.ToString("F0") + ":" + "0" + timer.ToString("F0");
        }
        else
        {
            scoreText.text = minuteCount.ToString("F0") + ":" + timer.ToString("F0");
        }
        highText.text = textFile.text;
        end.SetActive(false);
    }

    void Start()
    {
        myTest.text = test;
        highScoreText = textFile.text;
        Debug.Log(highScoreText);
        endMenu.SetActive(false);
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

        if (menuUp == false || gameFinish == false)
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

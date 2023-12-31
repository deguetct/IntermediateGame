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
    public float testing = 00.01f;


    [SerializeField] private BoxCollider2D endLine;
    [SerializeField] private GameObject endMenu;
    [SerializeField] private GameObject end;

    public int[] scores = new int[5];

    public string scoreFileName = "HighScoresList.txt";

    string currentDirectory;

    public float teste = 1;
    public float testScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameFinish = true;
        endMenu.SetActive(true);

      if (timer < 10)
        {
            scoreText.text = minuteCount.ToString("F0") + "." + "0" + timer.ToString("F2");
        }
        else
        {
            scoreText.text = minuteCount.ToString("F0") + ". " + timer.ToString("F2");
        }
        

        end.SetActive(false);
    }

    void Start()
    {
        myTest.text = test;
        endMenu.SetActive(false);

        currentDirectory = Application.dataPath;
        Debug.Log("Our current directory is: " + currentDirectory);
        loadScoresFromFile();
        SaveScoresToFile();
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
            if (gameFinish == false)
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
    void loadScoresFromFile()
    {
        bool fileExists = File.Exists(currentDirectory + "\\" + scoreFileName);
        if (fileExists == true)
        {
            Debug.Log("Found high score file " + scoreFileName);
        }
        else
        {
            Debug.Log("The file " + scoreFileName +
            " does not exist. No scores will be loaded.", this);
            return;
        }

        scores = new int[scores.Length];

        StreamReader fileReader = new StreamReader(currentDirectory + "\\" + scoreFileName);

        int scoreCount = 0;

        while (fileReader.Peek() != 0 && scoreCount < scores.Length)
        {

            string fileLine = fileReader.ReadLine();

            int readScore = -1;

            bool didParse = int.TryParse(fileLine, out readScore);
            if (didParse)
            {

                scores[scoreCount] = readScore;
            }
            else
            {

                Debug.Log("Invalid line in scores file at " + scoreCount +
                ", using default value.", this);
                scores[scoreCount] = 0;
            }

            scoreCount++;
        }

        fileReader.Close();
        Debug.Log("High scores read from " + scoreFileName);

    }

    public void SaveScoresToFile()
    {
        StreamWriter fileWriter = new StreamWriter(currentDirectory + "\\" + scoreFileName);

        for (int i = 0; i < scores.Length; i++)
        {
            fileWriter.WriteLine(scores[i]);
        }

        fileWriter.Close();

        Debug.Log("High scores written to " + scoreFileName);
    }

    public void AddScore(int newScore)
    {
        int desiredIndex = -1;
        for (int i = 0; i < scores.Length; i++)
        {

            if (scores[i] > newScore || scores[i] == 0)
            {
                desiredIndex = i;
                break;
            }
        }

        if (desiredIndex < 0)
        {
            Debug.Log("Score of " + newScore + " not high enough for high scores list.", this);
            return;
        }

        for (int i = scores.Length - 1; i > desiredIndex; i--)
        {
            scores[i] = scores[i - 1];
        }

        scores[desiredIndex] = newScore;
        Debug.Log("Score of " + newScore + " entered into high scores at position " + desiredIndex, this);
    }
}

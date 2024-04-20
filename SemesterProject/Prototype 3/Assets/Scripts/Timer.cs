using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
//using UnityEditor.PackageManager;

public class Timer : MonoBehaviour
{
    float time;
    float timerDelete;
    string timeLimit = " | 0:30";
    bool startDeleteMessage;
    bool levelOver = false;
    

    // Start is called before the first frame update
    void Start()
    {
        startDeleteMessage = false;
        timerDelete = 0.0f;
        time = 0.0f;
        GameObject.Find("TimerLabel").GetComponent<TextMeshProUGUI>().text = "";
        DisplayMessageToUser("");
        
    }

    // Update is called once per frame
    void Update()
    {
        
            time = time + Time.deltaTime;
            int seconds = (int)(time % 60);
            int minutes = (int)(time / 60);
            if (seconds < 31)
            {
                GameObject.Find("TimerLabel").GetComponent<TextMeshProUGUI>().text = "Time: 00:" + seconds + timeLimit;
            }

            //print(minutes + " minutes and " + seconds + " seconds");
            //print(minutes + ":" + seconds);

            if (startDeleteMessage == true)
            {
                timerDelete = timerDelete + Time.deltaTime;
                if (timerDelete >= 2.0f)
                {
                    DisplayMessageToUser("");
                    timerDelete = 0.0f;
                    startDeleteMessage = false;
                }
            }

            if (time > 19 && time < 21)
            {
                DisplayMessageToUser("10 seconds left!");
                startDeleteMessage = true;
            }

            if (time > 29)
            {
                DisplayMessageToUser("Times Up!");


            }

            if (time > 30)
            {
                levelOver = true;
                //SceneManager.LoadScene("FirstScene");
                GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets>().deleteOldQuestion(levelOver);
            }

            if (time >= 37)
            {
            //GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets>().levelOver();
            SceneManager.LoadScene("startMenu");
            }
        

    }
    public void DisplayMessageToUser(string messageToDisplay)
    {
        GameObject.Find("userMessageUI").GetComponent<TextMeshProUGUI>().text = messageToDisplay;
        startDeleteMessage = true;
    }

   

}

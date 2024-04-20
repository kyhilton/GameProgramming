using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using TMPro;
using UnityEngine;

public class DisplayEndLevelScores : MonoBehaviour
{

   // public TextMeshProUGUI ScoreLabel;
    private int score = 0;
    private int level = 0;
    // Start is called before the first frame update
    void Start()
   {
        method();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void method()
    {
        //if(PlayerPrefs.HasKey("Score") && PlayerPrefs.HasKey("Level"))
        //{
        //    score = PlayerPrefs.GetInt("Score");
        //    level = PlayerPrefs.GetInt("Level");
        //}

        //Debug.Log(PlayerPrefs.HasKey("Score"));
        //Debug.Log(level);
        //ScoreLabel.text = "You got " + score + " notes correct for level " + level + "!";
        GameObject.Find("ScoreManager").GetComponent<HighScoreControl>().GetScore();
    }


}

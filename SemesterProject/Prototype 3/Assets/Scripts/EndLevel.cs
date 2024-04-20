using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
//using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EndLevel : MonoBehaviour
{
    //public TextMeshProUGUI ScoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        displayScore();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void displayScore()
    {
       /* StreamReader reader = new StreamReader("score.txt");
        string score = reader.ReadLine();
        ScoreLabel.GetComponent<TextMeshProUGUI>().text = "You got " + score + " notes correct!";*/
    }

}

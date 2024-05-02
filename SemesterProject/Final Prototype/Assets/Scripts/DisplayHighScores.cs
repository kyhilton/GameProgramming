using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class DisplayHighScores : MonoBehaviour
{

    public TextMeshProUGUI ScoreLabel;
    private int highscore = 0;
   // Start is called before the first frame update
   void Start()
   {
        highscore = GameObject.Find("gameManager").GetComponent<HighScoreControl>().ReadString();
        ScoreLabel.text = "Highscore: " + Convert.ToString(highscore);
   }

   // Update is called once per frame
    void Update()
    {
        
    }

    
    

}

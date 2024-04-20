using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HighScoreControl : MonoBehaviour
{
    

    private string secretKey = "mySecretKey";
    public string addScoreURL =
            "http://localhost/fretboardfrenzy/addscore.php?";
    public string highscoreURL =
             "http://localhost/fretboardfrenzy/display.php";
   
    public TextMeshProUGUI ScoreLabel;
    public TextMeshProUGUI LevelLabel;

    private string Score;
    private string Level;

    public void GetScore()
    {
        //ScoreLabel.text = "Score: ";
        //LevelLabel.text = "Level: ";

        StartCoroutine(GetScores());
    }

    public void SendScore()
    {
        StartCoroutine(PostScores(Score,
           Convert.ToInt32(Level)));
        
    }

    public void SendScore(int score, int level)
    {
        Score = Convert.ToString(score);
        Level = Convert.ToString(level);
        //SendScore();
        Debug.Log(Score);
        Debug.Log(Level);
    }

    IEnumerator GetScores()
    {
        UnityWebRequest hs_get = UnityWebRequest.Get(highscoreURL);
        yield return hs_get.SendWebRequest();
        if (hs_get.error != null)
            Debug.Log("There was an error getting the high score: "
                    + hs_get.error);
        else
        {
            string dataText = hs_get.downloadHandler.text;
            MatchCollection mc = Regex.Matches(dataText, @"_");
            if (mc.Count > 0)
            {
                string[] splitData = Regex.Split(dataText, @"_");
                for (int i = 0; i < mc.Count; i++)
                {
                    if (i % 2 == 0) { 
                    ScoreLabel.text +=
                                        splitData[i];
                    Score = splitData[i]; }
                    else { 
                        LevelLabel.text +=
                                    splitData[i];
                    Level = splitData[i];
                    }
                }
            }
        }
    }

    IEnumerator PostScores(string score, int level)
    {
        string hash = HashInput(score + level + secretKey);
        string post_url = addScoreURL + "score=" +
               UnityWebRequest.EscapeURL(score) + "&level="
               + level + "&hash=" + hash;
        UnityWebRequest hs_post = UnityWebRequest.PostWwwForm(post_url, hash);
        yield return hs_post.SendWebRequest();
        if (hs_post.error != null)
            Debug.Log("There was an error posting the high score: "
                    + hs_post.error);
    }

    public string HashInput(string input)
    {
        SHA256Managed hm = new SHA256Managed();
        byte[] hashValue =
                hm.ComputeHash(System.Text.Encoding.ASCII.GetBytes(input));
        string hash_convert =
                 BitConverter.ToString(hashValue).Replace("-", "").ToLower();
        return hash_convert;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

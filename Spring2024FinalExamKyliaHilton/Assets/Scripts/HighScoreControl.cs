using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreControl : MonoBehaviour
{
    private string secretKey = "mySecretKey";
    public string addScoreURL =
            "http://localhost/green119/addscore.php?";
    public string highscoreURL =
             "http://localhost/green119/display.php";


    public Text HighScoresTextNames;
    public Text HighScoresTextScores;
    public Text name1;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Exit")
            GetScoreBtn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetScoreBtn()
    {

        HighScoresTextNames.text = "";
        HighScoresTextScores.text = "";
        StartCoroutine(GetScores());
    }
    public void SendScoreBtn()
    {
        Debug.Log(PlayerPrefs.GetString("PlayerName"));
        Debug.Log(PlayerPrefs.GetInt("PlayerScore"));

        StartCoroutine(PostScores(PlayerPrefs.GetString("PlayerName"),
           PlayerPrefs.GetInt("PlayerScore")));

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
                    if (i % 2 == 0)
                        HighScoresTextNames.text += splitData[i];

                    else
                        HighScoresTextScores.text += splitData[i];

                }
            }
        }
    }

    IEnumerator PostScores(string name, int score)
    {
        string hash = HashInput(name + score + secretKey);
        string post_url = addScoreURL + "name=" +
               UnityWebRequest.EscapeURL(name) + "&score="
               + score + "&hash=" + hash;
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
}

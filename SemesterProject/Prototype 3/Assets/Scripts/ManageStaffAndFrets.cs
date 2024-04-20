using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text.RegularExpressions;



public class ManageStaffAndFrets : MonoBehaviour
{

    private string secretKey = "mySecretKey";
    public string addScoreURL =
            "http://localhost/fretboardfrenzy/addscore.php?";

    private string Score;
    private string Level;

    public GameObject staff;
    public GameObject fret;

    public string question;
    public int lastRandom = 0;

    private bool noteSelected1;
    private GameObject note;

    public TextMeshProUGUI ScoreLabel;
    private int score = 0;
    private bool endLevel = false;

    
    public List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        
        sprites = new List<Sprite> {
        Resources.Load<Sprite>("E_1_Staff"),
        Resources.Load<Sprite>("F_1_Staff"),
        Resources.Load<Sprite>("G_1_Staff"),
        Resources.Load<Sprite>("E_1_Fret"),
        Resources.Load<Sprite>("F_1_Fret"),
        Resources.Load<Sprite>("G_1_Fret")
    };
        displayStaff();
        displayFrets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayStaff()
    {
        //Instantiate(staff, new Vector3 (0,0,0), Quaternion.identity);
        addAStaff(0);
    }

    public void addAStaff(int rank)
    {
        float noteOriginalScale = staff.transform.localScale.x;
        float scaleFactor = (350 * noteOriginalScale) / 100.0f;
        GameObject cen = GameObject.Find("centerOfScreen");
        Vector3 newPosition = new Vector3(cen.transform.position.x + ((rank/2) * scaleFactor), cen.transform.position.y, cen.transform.position.z);
        GameObject s = (GameObject)(Instantiate(staff, newPosition, Quaternion.identity));

        s.tag = "" + rank;
        s.name = "" + rank;
        string nameOfNote = "";
        string stringNumber = "_1_Staff";
        string fileName = "";
        int index = 0;
        int random = randomIntExcept(lastRandom);

      
            lastRandom = random;
            switch (random)
            {

                case 0:
                    nameOfNote = "E";
                    index = 0;
                    break;
                case 1:
                    nameOfNote = "F";
                    index = 1;
                    break;
                case 2:
                    nameOfNote = "G";
                    index = 2;
                    break;
            
           }
        fileName = nameOfNote + stringNumber;
        
        Sprite s1 = sprites[index];
        //print("S1" + s1);
        //GameObject.Find("" + rank).GetComponent<staff>().setOriginalSprite(s1);
        s.GetComponent<staff>().setOriginalSprite(s1);

        question = nameOfNote;
    }

    public void displayFrets()
    {
        for (int i = 1; i < 4; i++)
        {
            addFrets(i);
        }
    }

    public void addFrets(int rank)
    {
        float noteOriginalScale = fret.transform.localScale.x;
        float scaleFactor = (250 * noteOriginalScale) / 100.0f;
        GameObject cen = GameObject.Find("centerOfScreenChoices");
        Vector3 newPosition = new Vector3(cen.transform.position.x + ((rank-3/2) * scaleFactor), cen.transform.position.y, cen.transform.position.z);
        GameObject f = (GameObject)(Instantiate(fret, newPosition, Quaternion.identity));

        f.tag = "" + rank;
        f.name = "" + rank;
        string nameOfNote = "";
        string stringNumber = "_1_Fret";
        string fileName = "";
        int index = 0;

        switch (rank)
        {
            case 1:
                nameOfNote = "E";
                index = 3;
                break;
            case 2:
                nameOfNote = "F";
                index = 4;
                break;
            case 3:
                nameOfNote = "G";
                index = 5;
                break;
        }
        fileName = nameOfNote + stringNumber;

        //IMPORT
        Sprite s2 = sprites[index];
        //print("S2" + s2);
        //GameObject.Find("" + rank).GetComponent<fret>().setOriginaSprite(s2);
        f.GetComponent<fret>().setOriginaSprite(s2);

        /* s2 = (Sprite)Resources.UnloadAsset<Sprite>(fileName);*/
    }

    public void noteSelected(GameObject fret)
    {
        if (!noteSelected1)
        {
            noteSelected1 = true;
            note = fret;
            checkAnswer(question, note);

        }
    }

    public void checkAnswer(string answer, GameObject selectedNote)
    {
       string nameOfSelectedNote = "";
        int tagValue = Convert.ToInt32(selectedNote.tag);
        switch (tagValue)
        {
            case 1:
                nameOfSelectedNote = "E";
                break;
            case 2:
                nameOfSelectedNote = "F";
                break;
            case 3:
                nameOfSelectedNote = "G";
                break;
                
        }
        if (answer == nameOfSelectedNote)
        {
            //print("Correct");
            noteSelected1 = false;
            updateScore();
            deleteOldQuestion(endLevel);
            displayStaff();
            displayFrets();
        }
        else
        {
            //print("Incorrect");
            noteSelected1 = false;
        }

        //  GENERATE A NEW RANDOM NUMBER TO ASSOCIATE WITH A CORRECT COMBINATION OF STAFF AND FRET, PASS THAT TO THE ADDSTAFF AND ADDFRET. THEN YOU CAN RANDOMLY SELECT TWO OTHER FRETS TO ACT AS THE INCORRECT ANSWERS.


    }

    public void deleteOldQuestion(bool endlevel)
    {
        for (int i = 0; i < 4; i++)
        {
            Destroy(GameObject.Find("" + i));
        }
        question = "";
        if (endlevel == true)
        {
            //save scores to external storage then go to EndLevel scene
            GameObject.Find("Main Camera").GetComponent<Timer>().DisplayMessageToUser("You got " + score + " notes correct!");
            //GameObject.Find("gameManager").GetComponent<HighScoreControl>().SendScore(score, 1); // being called indefinitely, TRY PLACING CODE TO WRITE TO DB IN THIS CLASS INSTEAD OF HIGHSCORE CONTROL
            SendScore(score, 1);
            endLevel = false;
            
        }
    }

    public void updateScore()
    {
        score = score + 1;
        ScoreLabel.text = "Score: " + Convert.ToString(score);


    }

    public int randomIntExcept(int except)
    {   
        int number = UnityEngine.Random.Range(0, 3);
        do
        {
          number = UnityEngine.Random.Range(0, 3);
        } while (number == except);
        return number;
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
        SendScore();
        Debug.Log(Score);
        Debug.Log(Level);
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

}

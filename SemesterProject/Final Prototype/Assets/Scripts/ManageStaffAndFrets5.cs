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



public class ManageStaffAndFrets5 : MonoBehaviour
{

    

    private string Score;
    private string Level;

    public GameObject staff;
    public GameObject fret;

    public string question;
    public int lastRandom = 0;

    private bool noteSelected1;
    private GameObject note;

    public TextMeshProUGUI ScoreLabel;
    public TextMeshProUGUI ScoreValue;
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
        Resources.Load<Sprite>("B_2_Staff"),
        Resources.Load<Sprite>("C_2_Staff"),
        Resources.Load<Sprite>("D_2_Staff"),
        Resources.Load<Sprite>("E_1_Fret"),
        Resources.Load<Sprite>("F_1_Fret"),
        Resources.Load<Sprite>("G_1_Fret"),
        Resources.Load<Sprite>("B_2_Fret"),
        Resources.Load<Sprite>("C_2_Fret"),
        Resources.Load<Sprite>("D_2_Fret"),
        Resources.Load<Sprite>("G_3_Staff"),
        Resources.Load<Sprite>("A_3_Staff"),
        Resources.Load<Sprite>("G_3_Fret"),
        Resources.Load<Sprite>("A_3_Fret"),
        Resources.Load<Sprite>("D_4_Staff"),//16
        Resources.Load<Sprite>("E_4_Staff"),//17
        Resources.Load<Sprite>("F_4_Staff"),//18
        Resources.Load<Sprite>("D_4_Fret"),//19
        Resources.Load<Sprite>("E_4_Fret"),//20
        Resources.Load<Sprite>("F_4_Fret"),//21
        Resources.Load<Sprite>("A_5_Staff"),//22
        Resources.Load<Sprite>("B_5_Staff"),//23
        Resources.Load<Sprite>("C_5_Staff"),//24
        Resources.Load<Sprite>("A_5_Fret"),//25
        Resources.Load<Sprite>("B_5_Fret"),//26
        Resources.Load<Sprite>("C_5_Fret")//27
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
        string stringNumber = "";
        string fileName = "";
        int index = 0;
        int random = randomIntExcept(lastRandom);

      
            lastRandom = random;
            switch (random)
            {

                case 0:
                    nameOfNote = "E";
                    index = 0;
                    stringNumber = "_1_Staff";
                break;
                case 1:
                    nameOfNote = "F";
                    index = 1;
                    stringNumber = "_1_Staff";
                break;
                case 2:
                    nameOfNote = "G";
                    index = 2;
                    stringNumber = "_1_Staff";
                break;
                //new for level 2
            case 3:
                    nameOfNote = "B";
                    index = 3;
                    stringNumber = "_2_Staff";
                break;
            case 4:
                    nameOfNote = "C";
                    index = 4;
                    stringNumber = "_2_Staff";
                break;
            case 5:
                    nameOfNote = "D";
                    index = 5;
                    stringNumber = "_2_Staff";
                break;
            case 6:
                nameOfNote = "G";
                index = 12;
                stringNumber = "_3_Staff";
                break;
            case 7:
                nameOfNote = "A";
                index = 13;
                stringNumber = "_3_Staff";
                break;
            case 8:
                nameOfNote = "D";
                index = 16;
                stringNumber = "_4_Staff";
                break;
            case 9:
                nameOfNote = "E";
                index = 17;
                stringNumber = "_4_Staff";
                break;
            case 10:
                nameOfNote = "F";
                index = 18;
                stringNumber = "_4_Staff";
                break;
            case 11:
                nameOfNote = "A";
                index = 22;
                stringNumber = "_5_Staff";
                break;
            case 12:
                nameOfNote = "B";
                index = 23;
                stringNumber = "_5_Staff";
                break;
            case 13:
                nameOfNote = "C";
                index = 24;
                stringNumber = "_5_Staff";
                break;
        }

        fileName = nameOfNote + stringNumber;
        
        Sprite s1 = sprites[index];
        //print("S1" + s1);
        //GameObject.Find("" + rank).GetComponent<staff>().setOriginalSprite(s1);
        s.GetComponent<staff>().setOriginalSprite(s1);

        question = nameOfNote + stringNumber; // fix xhange answer to account for stringNumber
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
        string stringNumber = "";
        string fileName = "";
        int index = 0;

        //PROPOSED FOR HIGHER LEVEL - Implement if statement that displays the notes on a single string based on the value of question.
        if (question == "B_2_Staff" || question == "C_2_Staff" || question == "D_2_Staff")
        {
            switch (rank)
            {
                case 1:
                    nameOfNote = "B";
                    index = 9;
                    stringNumber = "_2_Fret";
                    break;
                case 2:
                    nameOfNote = "C";
                    index = 10;
                    stringNumber = "_2_Fret";
                    break;
                case 3:
                    nameOfNote = "D";
                    index = 11;
                    stringNumber = "_2_Fret";
                    break;
            }
        }
        else if (question == "E_1_Staff" || question == "F_1_Staff" || question == "G_1_Staff")
        {
            switch (rank)
            {
                case 1:
                    nameOfNote = "E";
                    index = 6;
                    stringNumber = "_1_Fret";
                    break;
                case 2:
                    nameOfNote = "F";
                    index = 7;
                    stringNumber = "_1_Fret";
                    break;
                case 3:
                    nameOfNote = "G";
                    index = 8;
                    stringNumber = "_1_Fret";
                    break;
            }
        }
        else if (question == "A_3_Staff" || question == "G_3_Staff")
        {
            switch (rank)
            {
                case 1:
                    nameOfNote = "G";
                    index = 14;
                    stringNumber = "_3_Fret";
                    break;
                case 2:
                    nameOfNote = "A";
                    index = 15;
                    stringNumber = "_3_Fret";
                    break;
                case 3:
                    nameOfNote = "B";
                    index = 9;
                    stringNumber = "_2_Fret";
                    break;
            }
        }
        else if (question == "D_4_Staff" || question == "E_4_Staff" || question == "F_4_Staff")
        {
            switch (rank)
            {
                case 1:
                    nameOfNote = "D";
                    index = 19;
                    stringNumber = "_4_Fret";
                    break;
                case 2:
                    nameOfNote = "E";
                    index = 20;
                    stringNumber = "_4_Fret";
                    break;
                case 3:
                    nameOfNote = "F";
                    index = 21;
                    stringNumber = "_4_Fret";
                    break;
            }
        }
        else if (question == "A_5_Staff" || question == "B_5_Staff" || question == "C_5_Staff")
        {
            switch (rank)
            {
                case 1:
                    nameOfNote = "A";
                    index = 25;
                    stringNumber = "_5_Fret";
                    break;
                case 2:
                    nameOfNote = "B";
                    index = 26;
                    stringNumber = "_5_Fret";
                    break;
                case 3:
                    nameOfNote = "C";
                    index = 27;
                    stringNumber = "_5_Fret";
                    break;
            }
        }



        //switch (rank)
        //{         
        //    case 1:
        //        nameOfNote = "E";
        //        index = 6; // change to reflect new values from sprites added to array list in start; for each case in this statement.
        //        break;
        //    case 2:
        //        nameOfNote = "F";
        //        index = 7;
        //        break;
        //    case 3:
        //        nameOfNote = "G";
        //        index = 8;
        //        break;
        //}

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

        if (answer == "B_2_Staff" || answer == "C_2_Staff" || answer == "D_2_Staff")
        {
            switch (tagValue)
            {
                case 1:
                    nameOfSelectedNote = "B_2_Staff";
                    break;
                case 2:
                    nameOfSelectedNote = "C_2_Staff";
                    break;
                case 3:
                    nameOfSelectedNote = "D_2_Staff";
                    break;
            }
        }
        else if (answer == "E_1_Staff" || answer == "F_1_Staff" || answer == "G_1_Staff")
        {
            switch (tagValue)
            {
                case 1:
                    nameOfSelectedNote = "E_1_Staff";
                    break;
                case 2:
                    nameOfSelectedNote = "F_1_Staff";
                    break;
                case 3:
                    nameOfSelectedNote = "G_1_Staff";
                    break;
            }
        }
        else if ( answer == "A_3_Staff" || answer == "G_3_Staff")
        {
            switch (tagValue)
            {
                case 1:
                    nameOfSelectedNote = "G_3_Staff";
                    break;
                case 2:
                    nameOfSelectedNote = "A_3_Staff";
                    break;
                case 3:
                    nameOfSelectedNote = "B_2_Staff";
                    break;
            }
        }
        else if (answer == "D_4_Staff" || answer == "E_4_Staff" || answer == "F_4_Staff")
        {
            switch (tagValue)
            {
                case 1:
                    nameOfSelectedNote = "D_4_Staff";
                    break;
                case 2:
                    nameOfSelectedNote = "E_4_Staff";
                    break;
                case 3:
                    nameOfSelectedNote = "F_4_Staff";
                    break;
            }
        }
        else if (answer == "A_5_Staff" || answer == "B_5_Staff" || answer == "C_5_Staff")
        {
            switch (tagValue)
            {
                case 1:
                    nameOfSelectedNote = "A_5_Staff";
                    break;
                case 2:
                    nameOfSelectedNote = "B_5_Staff";
                    break;
                case 3:
                    nameOfSelectedNote = "C_5_Staff";
                    break;
            }
        }

        //switch (tagValue)
        //{
        //    case 1:
        //        nameOfSelectedNote = "E";
        //        break;
        //    case 2:
        //        nameOfSelectedNote = "F";
        //        break;
        //    case 3:
        //        nameOfSelectedNote = "G";
        //        break;

        //}

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

            //write to score file
            GameObject.Find("gameManager").GetComponent<HighScoreControl>().WriteString();
            endLevel = false;
            
        }
    }

    public void updateScore()
    {
        score = score + 1;
        //ScoreLabel.text = "Score: " + Convert.ToString(score);
        ScoreValue.text = Convert.ToString(score);


    }

    public int randomIntExcept(int except)
    {   
        int number = UnityEngine.Random.Range(0, 14);
        do
        {
          number = UnityEngine.Random.Range(0, 14);
        } while (number == except);
        return number;
    }
    public GameObject retrieveSelectedAnswer()
    {
        return note;
    }

    public int retrieveScore()
    {
        return score;
    }
}

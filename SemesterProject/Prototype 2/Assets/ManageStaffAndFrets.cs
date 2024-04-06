using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ManageStaffAndFrets : MonoBehaviour
{
    public GameObject staff;
    public GameObject fret;

    public string question;

    private bool noteSelected1;
    private GameObject note;

    public TextMeshProUGUI ScoreLabel;
    private int score = 0;

    

    // Start is called before the first frame update
    void Start()
    {
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

        switch (UnityEngine.Random.Range(0, 3))
        {
            case 0:
                nameOfNote = "E";
                break;
            case 1:
                nameOfNote = "F";
                break;
            case 2:
                nameOfNote = "G";
                break;
        }
        fileName = nameOfNote + stringNumber;
        Debug.Log(fileName);
        Sprite s1 = (Sprite)(Resources.Load<Sprite>(fileName));
        print("S1" + s1);
        GameObject.Find("" + rank).GetComponent<staff>().setOriginalSprite(s1);

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

        switch (rank)
        {
            case 1:
                nameOfNote = "E";
                break;
            case 2:
                nameOfNote = "F";
                break;
            case 3:
                nameOfNote = "G";
                break;
        }
        fileName = nameOfNote + stringNumber;
        
        Sprite s2 = (Sprite)(Resources.Load<Sprite>(fileName));
        print("S2" + s2);
        GameObject.Find("" + rank).GetComponent<fret>().setOriginaSprite(s2);
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
            print("Correct");
            noteSelected1 = false;
            updateScore();
            deleteOldQuestion();
            displayStaff();
            displayFrets();
        }
        else
        {
            print("Incorrect");
            noteSelected1 = false;
        }



    }

    public void deleteOldQuestion()
    {
        for (int i = 0; i < 4; i++)
        {
            Destroy(GameObject.Find("" + i));
        }
        question = "";
    }

    public void updateScore()
    {
        score = score + 1;
        ScoreLabel.text = "Score: " + Convert.ToString(score);


    }
}

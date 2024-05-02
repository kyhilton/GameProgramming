using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyStringFour : MonoBehaviour
{
    public GameObject note;
    // Start is called before the first frame update
    void Start()
    {
        displayNotes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displayNotes()
    {
        //Instantiate(note, new Vector3(0,0,0), Quaternion.identity);
        //addANote(0);
        for (int i = 0; i < 3; i++)
        {
            addANote(i);
        }
    }

    void addANote(int rank)
    {
        //GameObject n = (GameObject)(Instantiate(note, new Vector3(0,0,0),Quaternion.identity));

        //GameObject n = (GameObject)(Instantiate(note, new Vector3(rank*3.0f, 0, 0), Quaternion.identity));

        

        
        float noteOriginalScale = note.transform.localScale.x;
        float scaleFactor = (350 * noteOriginalScale) / 100.0f;
        GameObject cen = GameObject.Find("centerOfScreen");
        Vector3 newPosition = new Vector3(cen.transform.position.x + ((rank-3/2) * scaleFactor), cen.transform.position.y, cen.transform.position.z);
        GameObject n = (GameObject)(Instantiate(note, newPosition, Quaternion.identity));
        
         n.tag = "" + rank;
         n.name = "" + rank;
         string nameOfNote = "";
         string stringNumber = "_4";
         string fileName = "";

         switch(rank)
         {
             case 0:
                 nameOfNote = "D";
                 break;
             case 1:
                 nameOfNote = "E";
                 break;
             case 2:
                 nameOfNote = "F";
                 break;
         }
         fileName = nameOfNote + stringNumber;
         Sprite s1 = (Sprite)(Resources.Load<Sprite>(fileName));
         print("S1" + s1);
         GameObject.Find("" + rank).GetComponent<note>().setOriginalSprite(s1);
         
        //GameObject n = (GameObject)(Instantiate(note, new Vector3(0,0,0), Quaternion.identity));
        //GameObject n = (GameObject)(Instantiate(note, new Vector3(rank * 3.0f,0,0), Quaternion.identity));
    }
}

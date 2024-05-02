using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HighScoreControl : MonoBehaviour
{


    public TextMeshProUGUI scoreText;
    private bool writtenToFile = false;
    public void WriteString()//NEED TO MAKE THIS PUBLIC SO WE CAN CONNECT TO BUTTON
    {
        if (writtenToFile == false)
        {
            string path = "Assets/Resources/scores.txt";

            // get text from the inputfield
            string dataToBeWritten = scoreText.text;

            //Write some text to the test.txt file
            StreamWriter writer = new StreamWriter(path, true); // append is true
            writer.WriteLine(dataToBeWritten); // notice that it does not write "written with method 1"
            writer.Close();

            //Re-import the file to update the reference in the editor
            //AssetDatabase.ImportAsset(path);
            TextAsset asset = (TextAsset)Resources.Load("scores"); // NEED TO CAST AS A TEXT ASSET SO IT CAN BE USED. TRY WITHOUT.

            //Print the text from the file
            Debug.Log("done writing with method 1");
            writtenToFile = true;
        }
    }

    public int ReadString() //NEED TO MAKE THIS PUBLIC SO WE CAN CONNECT TO BUTTON
    {

        string path = "Assets/Resources/scores.txt";
        string lineRead = "";
        int highscore = 0;

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream)
        {
            //Debug.Log(reader.ReadLine());
            lineRead = reader.ReadLine();

            if (Convert.ToInt32(lineRead) > highscore)
            {
                highscore = Convert.ToInt32(lineRead);
            }
            Debug.Log(lineRead);
            
        }
        reader.Close();

        return highscore;
    }

    public void GetScore() { }
}

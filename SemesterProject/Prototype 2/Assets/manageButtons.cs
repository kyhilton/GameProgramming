using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manageButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("startMenu");   
    }

    public void LoadRules()
    {
        SceneManager.LoadScene("viewRules");
    }
    public void LoadLevels()
    {
        SceneManager.LoadScene("levelSelect");
    }

    public void LoadFretboardDiagramInfo()
    {
        SceneManager.LoadScene("infoFretboard");
    }

    public void LoadStudyNotesMenu()
    {
        SceneManager.LoadScene("studyNotesMenu");
    }

    public void StudyString1()
    {
        SceneManager.LoadScene("viewNotes1");
    }

    public void StudyString2()
    {
        SceneManager.LoadScene("viewNotes2");
    }
    public void StudyString3()
    {
        SceneManager.LoadScene("viewNotes3");
    }

    public void StudyString4()
    {
        SceneManager.LoadScene("viewNotes4");
    }

    public void StudyString5()
    {
        SceneManager.LoadScene("viewNotes5");
    }

    public void StudyString6()
    {
        SceneManager.LoadScene("viewNotes6");
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene("playLevel1");
    }
}

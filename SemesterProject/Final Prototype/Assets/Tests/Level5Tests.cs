using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement; // for loading and  restarting game
using UnityEngine.InputSystem;// so we can use mouse and keyboard
using UnityEngine.UI;// so we can click on UI elements
using System; // for conversion between integers and text if needed.


public class Level5Tests: InputTestFixture
{
    
    Mouse mouse;
    Keyboard keyboard;  
    
    public override void Setup()
    {
        SceneManager.LoadScene("playLevel5");
        base.Setup();
        mouse = InputSystem.AddDevice<Mouse>();
        keyboard = InputSystem.AddDevice<Keyboard>();
    }

    public override void TearDown() // overrides inputtestfixture.teardown()
    {
        base.TearDown();
        SceneManager.LoadScene("playLevel5"); // Unloading the last loaded scene Assets/Resources/test_scene.unity(build index: 0), is not supported. Please use SceneManager.LoadScene()/EditorSceneManager.OpenScene() to switch to another scene.
    }

    public void ClickUI(GameObject uiElement)// so we can click on any UI element we choose
    {
        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector2 screenPosition = camera.WorldToScreenPoint(uiElement.transform.position);
        Set(mouse.position, screenPosition);
        Click(mouse.leftButton);
        //Release(mouse.leftButton); // need to release??
    }

    [UnityTest]
    public IEnumerator StaffLoads()
    {
        GameObject staff = GameObject.Find("0");
        yield return new WaitForSeconds(.1f);
        Assert.That(staff, Is.Not.Null);
    }

    [UnityTest]

    public IEnumerator FretsLoad()
    {
        
            GameObject fret1 = GameObject.Find("1");
            GameObject fret2 = GameObject.Find("2");
            GameObject fret3 = GameObject.Find("3");

        if (fret1 != null && fret2 != null && fret3 != null)
        {
            GameObject fretsloaded = GameObject.Find("3");
            yield return new WaitForSeconds(.1f);
            Assert.That(fretsloaded, Is.Not.Null);
        }

    }

    [UnityTest]
    public IEnumerator AnswerSelected()
    {
        // Wait for the scene to load
        yield return new WaitForSeconds(1f);

        // Find the Play button
        GameObject Choice = GameObject.Find("1");

        // Assert that the button is not null
        Assert.IsNotNull(Choice, "0 not found in Intro scene");

        // Simulate a button click
        Choice.GetComponent<fret>().OnMouseDown();

        GameObject AnswerSelected = GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets5>().retrieveSelectedAnswer();

        // Wait for the scene transition
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.That(AnswerSelected, Is.Not.Null);
        
    }

    [UnityTest]
    public IEnumerator ScoreIncreases()
    {
        yield return new WaitForSeconds(1f);

        for (int i = 1; i < 4; i++)
        {
            GameObject Choice = GameObject.Find("" + i + "");
            Assert.IsNotNull(Choice, i + " not found in Intro scene");
            Choice.GetComponent<fret>().OnMouseDown();
        }
        
        int score = GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets5>().retrieveScore();
        
        yield return new WaitForSeconds(1f);

        // Assert that the current scene is now the Game scene
        Assert.AreNotEqual(score, 0);
    }
    [UnityTest]
    public IEnumerator BackButtonWorks()
    {

        yield return new WaitForSeconds(1f);


        GameObject Button = GameObject.Find("backButton");


        Assert.IsNotNull(Button, "Back button not found in Intro scene");


        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();


        yield return new WaitForSeconds(1f);


        Assert.AreEqual("levelSelect", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking Back button");
    }
}


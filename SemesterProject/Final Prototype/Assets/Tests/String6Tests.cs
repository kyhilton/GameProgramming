using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement; // for loading and  restarting game
using UnityEngine.InputSystem;// so we can use mouse and keyboard
using UnityEngine.UI;// so we can click on UI elements
using System; // for conversion between integers and text if needed.


public class String6Tests: InputTestFixture
{
    
    Mouse mouse;
    Keyboard keyboard;  
    
    public override void Setup()
    {
        SceneManager.LoadScene("viewNotes6");
        base.Setup();
        mouse = InputSystem.AddDevice<Mouse>();
        keyboard = InputSystem.AddDevice<Keyboard>();
    }

    public override void TearDown() // overrides inputtestfixture.teardown()
    {
        base.TearDown();
        SceneManager.LoadScene("viewNotes6"); // Unloading the last loaded scene Assets/Resources/test_scene.unity(build index: 0), is not supported. Please use SceneManager.LoadScene()/EditorSceneManager.OpenScene() to switch to another scene.
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

    public IEnumerator FretsLoad()
    {
        
            GameObject note1 = GameObject.Find("0");
            GameObject note2 = GameObject.Find("1");
            GameObject note3 = GameObject.Find("2");

        if (note1 != null && note2 != null && note3 != null)
        {
            GameObject notesloaded = GameObject.Find("2");
            yield return new WaitForSeconds(.1f);
            Assert.That(notesloaded, Is.Not.Null);
        }

    }

    [UnityTest]
    public IEnumerator BackButtonWorks()
    {
        
        yield return new WaitForSeconds(1f);

        
        GameObject Button = GameObject.Find("backButton");

        
        Assert.IsNotNull(Button, "Back button not found in Intro scene");

        
        Button.GetComponent<UnityEngine.UI.Button>().onClick.Invoke();

        
        yield return new WaitForSeconds(1f);

        
        Assert.AreEqual("studyNotesMenu", SceneManager.GetActiveScene().name, "Game scene not loaded after clicking Back button");
    }
}


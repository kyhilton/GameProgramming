using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement; // for loading and  restarting game
using UnityEngine.InputSystem;// so we can use mouse and keyboard
using UnityEngine.UI;// so we can click on UI elements
using System; // for conversion between integers and text if needed.


public class TestScript: InputTestFixture
{
    
    Mouse mouse;
    Keyboard keyboard;

    public override void Setup()
    {
        SceneManager.LoadScene("playLevel1");
        base.Setup();
        mouse = InputSystem.AddDevice<Mouse>();
        keyboard = InputSystem.AddDevice<Keyboard>();
    }

    public override void TearDown() // overrides inputtestfixture.teardown()
    {
        base.TearDown();
        SceneManager.LoadScene("playLevel1"); // Unloading the last loaded scene Assets/Resources/test_scene.unity(build index: 0), is not supported. Please use SceneManager.LoadScene()/EditorSceneManager.OpenScene() to switch to another scene.
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
        yield return null;
    }

    [UnityTest]
    public IEnumerator ScoreIncreases()
    {
        yield return null;
    }
}


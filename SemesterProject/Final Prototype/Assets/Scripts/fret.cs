using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class fret : MonoBehaviour
{
    
    public Sprite originalSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        //print("You pressed fret.");
        //GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets>().noteSelected(gameObject);
        //GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets2>().noteSelected(gameObject);
        switch (GameObject.Find("gameLevel").GetComponent<TextMeshProUGUI>().text)
        {
            case "1":
                GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets>().noteSelected(gameObject);
                break;
            case "2":
                GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets2>().noteSelected(gameObject);
                break;
            case "3":
                GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets3>().noteSelected(gameObject);
                break;
            case "4":
                GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets4>().noteSelected(gameObject);
                break;
            case "5":
                GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets5>().noteSelected(gameObject);
                break;
            case "6":
                GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets6>().noteSelected(gameObject);
                break;
        }
    }

    public void setOriginaSprite(Sprite newSprite)
    {

        originalSprite = newSprite;
        //print(newSprite);
        //GetComponent<SpriteRenderer>().sprite = originalSprite;
        GetComponent<SpriteRenderer>().sprite = originalSprite;

    }


}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
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
        print("You pressed fret.");
        GameObject.Find("gameManager").GetComponent<ManageStaffAndFrets>().noteSelected(gameObject);
    }

    public void setOriginaSprite(Sprite newSprite)
    {

        originalSprite = newSprite;
        print(newSprite);
        //GetComponent<SpriteRenderer>().sprite = originalSprite;
        GetComponent<SpriteRenderer>().sprite = originalSprite;

    }


}

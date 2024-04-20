using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staff : MonoBehaviour
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

    public void setOriginalSprite(Sprite newSprite)
    {
        
        originalSprite = newSprite;
        //print(newSprite);
        GetComponent<SpriteRenderer>().sprite = originalSprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CreateTargets : MonoBehaviour
{
    public GameObject Target;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Target, new Vector3(3, 1, -3), Quaternion.identity);
        Instantiate(Target, new Vector3(4, 1, 1), Quaternion.identity);
        Instantiate(Target, new Vector3(2, 1, 2), Quaternion.identity);
        Instantiate(Target, new Vector3(-3, 1, 3), Quaternion.identity);
        Instantiate(Target, new Vector3(-4, 1, -4), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

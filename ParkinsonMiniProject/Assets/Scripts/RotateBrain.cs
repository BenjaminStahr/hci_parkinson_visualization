using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBrain : MonoBehaviour
{
    int rotationSpeed = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation on y axis
        transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
    }
}

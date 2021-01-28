using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorLoopBehavior : MonoBehaviour
{
    public bool isVisible;
    public bool colorIt;
    public Material baseColor;
    public Material lightUpColor;
    // Start is called before the first frame update
    void Start()
    {
        //isVisible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        VisibilityCheck();
        ChangeAreaColor();
    }

    public void VisibilityCheck()
    {
        //Manually making object visible for 
        if (isVisible)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
        else if (!isVisible)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    public void ChangeAreaColor()
    {
        MeshRenderer areaMeshRenderer = GetComponent<MeshRenderer>();
        if (colorIt)
        {
            areaMeshRenderer.material = lightUpColor;
        }
        else if (!colorIt)
        {
            areaMeshRenderer.material = baseColor;
        }
    }
}

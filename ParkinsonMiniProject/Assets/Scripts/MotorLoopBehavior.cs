using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorLoopBehavior : MonoBehaviour
{
    public bool isVisible;
    public bool colorIt;
    public Material baseColor;
    public Material lightUpColor;
    public GameObject PutamenLeft;
    public GameObject PutamenRight;
    public GameObject ThalamusLeft;
    public GameObject ThalamusRight;
    public GameObject CortexRight;
    public GameObject CortexLeft;
    public GameObject GlobusBrainLeft;
    public GameObject GlobusBrainRight;
    public float starting = 2.0f;
    public float repeating = 2.0f;
    float SinceLastFrame;
    public int CurrentAreaIndex;
    GameObject[] leftParts;
    GameObject[] rightParts;
    public bool looping;
    Color LoopCurrentColor = new Color32(250, 241, 39, 255);
    //250, 241, 39, 255
    // Start is called before the first frame update
    void Start()
    {
        GlobusBrainLeft = GameObject.FindGameObjectWithTag("GlobusBrainLeft");
        GlobusBrainRight = GameObject.FindGameObjectWithTag("GlobusBrainRight");
        PutamenLeft = GameObject.FindGameObjectWithTag("PutamenLeft");
        PutamenRight = GameObject.FindGameObjectWithTag("PutamenRight");
        ThalamusLeft = GameObject.FindGameObjectWithTag("ThalamusLeft");
        ThalamusRight = GameObject.FindGameObjectWithTag("ThalamusRight");
        CortexLeft = GameObject.FindGameObjectWithTag("CortexLeft");
        CortexRight = GameObject.FindGameObjectWithTag("CortexRight");
        
        //GlobusBrainLeft.GetComponent<Outline>().OutlineWidth = 0;
        //GlobusBrainRight.GetComponent<Outline>().OutlineWidth = 0;
        leftParts = new GameObject[4] { CortexLeft, PutamenLeft, GlobusBrainLeft, ThalamusLeft };
        rightParts = new GameObject[4] { CortexRight, PutamenRight, GlobusBrainRight, ThalamusRight};

        SinceLastFrame = Time.time;
        CurrentAreaIndex = 0;
        //GetComponentInParent<GameManager>().DeactivateAllOutlines();
        looping = false;
    }

    // Update is called once per frame
    void Update()
    {
        //VisibilityCheck();
        //ChangeAreaColor();
        //InvokeRepeating("ShowMotorLoop", starting, repeating);
        if (looping) {
            

            if (Time.time - SinceLastFrame > repeating)
            {
                SinceLastFrame = Time.time;
                if (CurrentAreaIndex < leftParts.Length)
                {
                    if (CurrentAreaIndex != 0) {
                        leftParts[CurrentAreaIndex - 1].GetComponent<Outline>().OutlineWidth = 0;                        
                        rightParts[CurrentAreaIndex - 1].GetComponent<Outline>().OutlineWidth = 0;
                    }
                    else if (CurrentAreaIndex == 0)
                    {
                        leftParts[leftParts.Length - 1].GetComponent<Outline>().OutlineWidth = 0;
                        rightParts[leftParts.Length - 1].GetComponent<Outline>().OutlineWidth = 0;
                    }

                    leftParts[CurrentAreaIndex].GetComponent<Outline>().enabled = true;
                    rightParts[CurrentAreaIndex].GetComponent<Outline>().enabled = true;
                    leftParts[CurrentAreaIndex].GetComponent<Outline>().OutlineColor = LoopCurrentColor;
                    rightParts[CurrentAreaIndex].GetComponent<Outline>().OutlineColor = LoopCurrentColor;
                    leftParts[CurrentAreaIndex].GetComponent<Outline>().OutlineWidth = 7;
                    rightParts[CurrentAreaIndex].GetComponent<Outline>().OutlineWidth = 7;
                    //gameObject.transform.GetChild(CurrentAreaIndex).GetComponent<Light>().enabled = true;
                    
                    CurrentAreaIndex++;
                    if (CurrentAreaIndex == leftParts.Length)
                    {
                        CurrentAreaIndex = 0;
                    }
                }
            }
        }
        
    }

    public void ShowMotorLoop()
    {

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
    public void EnableOutlines()
    {
        PutamenLeft.GetComponent<Outline>().enabled = true;
        PutamenRight.GetComponent<Outline>().enabled = true;
        ThalamusLeft.GetComponent<Outline>().enabled = true;
        ThalamusRight.GetComponent<Outline>().enabled = true;
        CortexRight.GetComponent<Outline>().enabled = true;
        CortexLeft.GetComponent<Outline>().enabled = true;
    }
    public void StartLooping()
    {
        looping = true;
    }
    
}

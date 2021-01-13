using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum AppState
{
    Information,
    DBS
}

public class GameManager : MonoBehaviour
{
    public AppState current;
    public GameObject ModusButton;
    public GameObject GlobusButton;
    public GameObject SubtantiaButton;
    public GameObject NucleusButton;
    public GameObject GlobusDBSButton;
    public GameObject NucleusDBSButton;
    public GameObject InfoText;
    public GameObject TotalBrain;
    public GameObject GlobusBrainLeft;
    public GameObject GlobusBrainRight;
    public GameObject NucleusBrainLeft;
    public GameObject NucleusBrainRight;

    int rotationSpeed = 15;
    Color DBSNucleusColor = new Color32(2,232,253,255);
    Color DBSGlobusColor = new Color32(253,241,5,255);
    Color InfoNucleusColor = new Color32(10,43,253,255);
    Color InfoGlobusColor = new Color32(253,178,5,255);

    // Start is called before the first frame update
    void Start()
    {
        current = AppState.Information;
        ModusButton = GameObject.FindGameObjectWithTag("Modus");
        GlobusButton = GameObject.FindGameObjectWithTag("Globus");
        SubtantiaButton = GameObject.FindGameObjectWithTag("Subtantia");
        NucleusButton = GameObject.FindGameObjectWithTag("Nucleus");
        GlobusDBSButton = GameObject.FindGameObjectWithTag("GlobusDBS");
        NucleusDBSButton = GameObject.FindGameObjectWithTag("NucleusDBS");
        InfoText = GameObject.FindGameObjectWithTag("InfoText");
        TotalBrain = GameObject.FindGameObjectWithTag("Brain");
        GlobusBrainLeft = GameObject.FindGameObjectWithTag("GlobusBrainLeft");
        GlobusBrainRight = GameObject.FindGameObjectWithTag("GlobusBrainRight");
        NucleusBrainLeft = GameObject.FindGameObjectWithTag("NucleusBrainLeft");
        NucleusBrainRight = GameObject.FindGameObjectWithTag("NucleusBrainRight");

        GlobusDBSButton.SetActive(false);
        NucleusDBSButton.SetActive(false);
    }

    void Update()
    {
        switch (current)
        {
            case AppState.Information:
                NucleusButton.SetActive(true);
                SubtantiaButton.SetActive(true);
                GlobusButton.SetActive(true);
                GlobusDBSButton.SetActive(false);
                NucleusDBSButton.SetActive(false);
                //change colours of brain areas
                GlobusBrainLeft.GetComponent<Renderer>().material.color = InfoGlobusColor;
                GlobusBrainRight.GetComponent<Renderer>().material.color = InfoGlobusColor;
                NucleusBrainLeft.GetComponent<Renderer>().material.color = InfoNucleusColor;
                NucleusBrainRight.GetComponent<Renderer>().material.color = InfoNucleusColor;
                break;
            case AppState.DBS:
                NucleusButton.SetActive(false);
                SubtantiaButton.SetActive(false);
                GlobusButton.SetActive(false);
                GlobusDBSButton.SetActive(true);
                NucleusDBSButton.SetActive(true);
                //change colours of brain areas
                GlobusBrainLeft.GetComponent<Renderer>().material.color = DBSGlobusColor;
                GlobusBrainRight.GetComponent<Renderer>().material.color = DBSGlobusColor;
                NucleusBrainLeft.GetComponent<Renderer>().material.color = DBSNucleusColor;
                NucleusBrainRight.GetComponent<Renderer>().material.color = DBSNucleusColor;
                break;
            default:
                break;
        }
    }
    public void SwitchMode()
    {
        if (current == AppState.Information)
        {
            current = AppState.DBS;
            ModusButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DBS";
        }
        else
        {
            current = AppState.Information;
            ModusButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Information";
        }
    }

    public void SetTextNucleus()
    {
        InfoText.GetComponent<TextMesh>().text = "Nucleus";
        //hier dann auch den entsprechenden Text vorlesen
    }
    public void SetTextSubtantia()
    {
        InfoText.GetComponent<TextMesh>().text = "Subtantia";
        //hier dann auch den entsprechenden Text vorlesen
    }
    public void SetTextGlobus()
    {
        InfoText.GetComponent<TextMesh>().text = "Globus";
        //hier dann auch den entsprechenden Text vorlesen
    }
    public void SetTextNucleusDBS()
    {
        InfoText.GetComponent<TextMesh>().text = "Nucleus DBS";
        //hier dann auch den entsprechenden Text vorlesen
    }
    public void SetTextGlobusDBS()
    {
        InfoText.GetComponent<TextMesh>().text = "Globus DBS";
        //hier dann auch den entsprechenden Text vorlesen
    }
 
}

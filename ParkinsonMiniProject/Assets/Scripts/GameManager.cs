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
    public GameObject SubtantiaBrainLeft;
    public GameObject SubtantiaBrainRight;
    public GameObject[] ElectrodeGP;
    public GameObject[] ElectrodeSTN;

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
        SubtantiaBrainLeft = GameObject.FindGameObjectWithTag("SubtantiaBrainLeft");
        SubtantiaBrainRight = GameObject.FindGameObjectWithTag("SubtantiaBrainRight");
        ElectrodeGP = GameObject.FindGameObjectsWithTag("ElectrodeGP");
        ElectrodeSTN = GameObject.FindGameObjectsWithTag("ElectrodeSTN");
        foreach (GameObject electrode in ElectrodeGP) {
            electrode.SetActive(false);
        }
        
        foreach (GameObject electrode in ElectrodeSTN)
        {
            electrode.SetActive(false);
        }
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
                foreach (GameObject electrode in ElectrodeGP)
                {
                    electrode.SetActive(false);
                }
                foreach (GameObject electrode in ElectrodeSTN)
                {
                    electrode.SetActive(false);
                }
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
                foreach (GameObject electrode in ElectrodeGP)
                {
                    electrode.SetActive(true);
                }
                foreach (GameObject electrode in ElectrodeSTN)
                {
                    electrode.SetActive(true);
                }
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
        InfoText.GetComponent<TextMesh>().text = "Er ist bei  Parkinson überaktiv.\n " +
            "Löst primär das Zittern/Ruhetremor aus. \n" +
            "Durch die Krankheit wird der Thalamus gehemmt, " +
            "was die Anregung\n des Motorcortex (gibt Bewegungsbefehle an Muskeln)\n weniger wahrscheinlich macht.";
        //hier dann auch den entsprechenden Text vorlesen
        DeactivateAllOutlines();
        NucleusBrainLeft.GetComponent<Outline>().enabled = true;
        NucleusBrainRight.GetComponent<Outline>().enabled = true;
    }
    public void SetTextSubtantia()
    {
        InfoText.GetComponent<TextMesh>().text = "Sie liegt nahe dem Hirnstamm, welcher\n Bewegungen berechnet und einleitet. " +
            "Die Stelle reagiert auf Dopamin,\n um richtig zu funktionieren." +
            " Die Substantia Nigra besteht z.T.\n aus dopamin-liefernde Nerven,\n" +
            " welche bei Parkinson absterben. Sie ist die Stelle im Kopf,\n die am meisten betroffen ist.";
        //hier dann auch den entsprechenden Text vorlesen
        DeactivateAllOutlines();
        SubtantiaBrainLeft.GetComponent<Outline>().enabled = true;
        SubtantiaBrainRight.GetComponent<Outline>().enabled = true;
    }
    public void SetTextGlobus()
    {
        InfoText.GetComponent<TextMesh>().text = "Weiteres Nervenzentrum für Balance, Bewegung und Laufen.\n " +
            "Unterversorgung, z.B. mit Dopamin, führt\n zu gestörter Funktionalität.";
        //hier dann auch den entsprechenden Text vorlesen
        DeactivateAllOutlines();
        GlobusBrainLeft.GetComponent<Outline>().enabled = true;
        GlobusBrainRight.GetComponent<Outline>().enabled = true;
    }
    public void SetTextNucleusDBS()
    {
        InfoText.GetComponent<TextMesh>().text = "Oft wird diese Stelle ausgenutzt.\n " +
            "Durch Erkrankung überaktiv und mit Impulsen\n wird diese Fehlfunktion wesentlich verbessert.";
        //hier dann auch den entsprechenden Text vorlesen
        DeactivateAllOutlines();
        NucleusBrainLeft.GetComponent<Outline>().enabled = true;
        NucleusBrainRight.GetComponent<Outline>().enabled = true;
        foreach (GameObject electrode in ElectrodeGP)
        {
            electrode.GetComponent<electrodeBehavior>().specular = false;
        }
        foreach (GameObject electrode in ElectrodeSTN)
        {
            electrode.GetComponent<electrodeBehavior>().specular = true;
        }
    }
    public void SetTextGlobusDBS()
    {
        InfoText.GetComponent<TextMesh>().text = "Diese Stelle wird in Spätphasen der Erkrankung genutzt.\n " +
            "Impulse synchronisieren das Verhalten,\n was gestört wird und lindert so Symptome.";
        //hier dann auch den entsprechenden Text vorlesen
        DeactivateAllOutlines();
        GlobusBrainLeft.GetComponent<Outline>().enabled = true;
        GlobusBrainRight.GetComponent<Outline>().enabled = true;
        foreach (GameObject electrode in ElectrodeSTN)
        {
            electrode.GetComponent<electrodeBehavior>().specular = false;
        }
        foreach (GameObject electrode in ElectrodeGP)
        {
            electrode.GetComponent<electrodeBehavior>().specular = true;
        }
    }
    public void DeactivateAllOutlines()
    {
        GlobusBrainLeft.GetComponent<Outline>().enabled = false;
        GlobusBrainRight.GetComponent<Outline>().enabled = false;
        SubtantiaBrainLeft.GetComponent<Outline>().enabled = false;
        SubtantiaBrainRight.GetComponent<Outline>().enabled = false;
        NucleusBrainLeft.GetComponent<Outline>().enabled = false;
        NucleusBrainRight.GetComponent<Outline>().enabled = false;
    }
}

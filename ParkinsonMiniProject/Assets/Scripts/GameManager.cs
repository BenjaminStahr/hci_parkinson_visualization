using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum AppState
{
    Information,
    DBS,
    Loop
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
    public GameObject BasalButton;
    public GameObject ThalamusButton;
    public GameObject CortexButton;
    public GameObject InfoText;
    public GameObject TotalBrain;
    public GameObject GlobusBrainLeft;
    public GameObject GlobusBrainRight;
    public GameObject NucleusBrainLeft;
    public GameObject NucleusBrainRight;
    public GameObject SubtantiaBrainLeft;
    public GameObject SubtantiaBrainRight;
    public GameObject PutamenLeft;
    public GameObject PutamenRight;
    public GameObject ThalamusLeft;
    public GameObject ThalamusRight;
    public GameObject CortexRight;
    public GameObject CortexLeft;
    public GameObject[] ElectrodeGP;
    public GameObject[] ElectrodeSTN;
    public GameObject[] electrodeLights;
    public GameObject[] electrodeLightsSTN;

    int rotationSpeed = 15;
    Color DBSNucleusColor = new Color32(2,232,253,255);
    Color DBSGlobusColor = new Color32(253,241,5,255);
    Color InfoNucleusColor = new Color32(10,43,253,255);
    Color InfoGlobusColor = new Color32(253,178,5,255);
    Color LoopPartColor = new Color32(239, 255, 0, 255);
    Color OutlineColor = new Color32(0, 185, 255, 255);
    
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
        BasalButton = GameObject.FindGameObjectWithTag("BasalGanglia");
        ThalamusButton = GameObject.FindGameObjectWithTag("ThalamusButton");
        CortexButton = GameObject.FindGameObjectWithTag("MotorCortex");
        InfoText = GameObject.FindGameObjectWithTag("InfoText");
        TotalBrain = GameObject.FindGameObjectWithTag("Brain");
        GlobusBrainLeft = GameObject.FindGameObjectWithTag("GlobusBrainLeft");
        GlobusBrainRight = GameObject.FindGameObjectWithTag("GlobusBrainRight");
        NucleusBrainLeft = GameObject.FindGameObjectWithTag("NucleusBrainLeft");
        NucleusBrainRight = GameObject.FindGameObjectWithTag("NucleusBrainRight");
        SubtantiaBrainLeft = GameObject.FindGameObjectWithTag("SubtantiaBrainLeft");
        SubtantiaBrainRight = GameObject.FindGameObjectWithTag("SubtantiaBrainRight");
        PutamenLeft = GameObject.FindGameObjectWithTag("PutamenLeft");
        PutamenRight = GameObject.FindGameObjectWithTag("PutamenRight");
        ThalamusLeft = GameObject.FindGameObjectWithTag("ThalamusLeft");
        ThalamusRight = GameObject.FindGameObjectWithTag("ThalamusRight");
        CortexLeft = GameObject.FindGameObjectWithTag("CortexLeft");
        CortexRight = GameObject.FindGameObjectWithTag("CortexRight");
        ThalamusRight = GameObject.FindGameObjectWithTag("ThalamusRight");
        ElectrodeGP = GameObject.FindGameObjectsWithTag("ElectrodeGP");       
        ElectrodeSTN = GameObject.FindGameObjectsWithTag("ElectrodeSTN");
        electrodeLights = GameObject.FindGameObjectsWithTag("ElectrodeLight");
        electrodeLightsSTN = GameObject.FindGameObjectsWithTag("ElectrodeLightSTN");
        
        /**
        foreach (GameObject electrodeLight in electrodeLights)
        {
            electrodeLight.GetComponent<Light>().enabled = false;
        }*/
        GlobusDBSButton.SetActive(false);
        NucleusDBSButton.SetActive(false);
        BasalButton.SetActive(false);
        ThalamusButton.SetActive(false);
        CortexButton.SetActive(false);
        PutamenLeft.SetActive(false);
        PutamenRight.SetActive(false);
        ThalamusRight.SetActive(false);
        ThalamusLeft.SetActive(false);
        CortexLeft.SetActive(false);
        CortexRight.SetActive(false);
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
                BasalButton.SetActive(false);
                ThalamusButton.SetActive(false);
                CortexButton.SetActive(false);
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
                GlobusBrainLeft.SetActive(true);
                GlobusBrainRight.SetActive(true);
                PutamenLeft.SetActive(false);
                PutamenRight.SetActive(false);
                ThalamusRight.SetActive(false);
                ThalamusLeft.SetActive(false);
                CortexLeft.SetActive(false);
                CortexRight.SetActive(false);
                NucleusButton.SetActive(false);
                SubtantiaButton.SetActive(false);
                GlobusButton.SetActive(false);
                GlobusDBSButton.SetActive(true);
                NucleusDBSButton.SetActive(true);
                BasalButton.SetActive(false);
                ThalamusButton.SetActive(false);
                CortexButton.SetActive(false);

                foreach (GameObject electrode in ElectrodeGP)
                {
                    electrode.SetActive(true);
                }
                foreach (GameObject electrode in ElectrodeSTN)
                {
                    electrode.SetActive(true);
                }

                //change colours of brain areas
                GlobusBrainLeft.GetComponent<Outline>().OutlineColor = OutlineColor;
                GlobusBrainRight.GetComponent<Outline>().OutlineColor = OutlineColor;
                GlobusBrainLeft.GetComponent<Outline>().OutlineWidth = 2;
                GlobusBrainRight.GetComponent<Outline>().OutlineWidth = 2;
                GlobusBrainLeft.GetComponent<Renderer>().material.color = DBSGlobusColor;
                GlobusBrainRight.GetComponent<Renderer>().material.color = DBSGlobusColor;
                NucleusBrainLeft.GetComponent<Renderer>().material.color = DBSNucleusColor;
                NucleusBrainRight.GetComponent<Renderer>().material.color = DBSNucleusColor;
                break;
            case AppState.Loop:
                Debug.Log("app state loop");
                PutamenLeft.SetActive(true);
                PutamenRight.SetActive(true);
                ThalamusRight.SetActive(true);
                ThalamusLeft.SetActive(true);
                CortexLeft.SetActive(true);
                CortexRight.SetActive(true);

                SetTextLoops();
                
                ThalamusRight.GetComponent<Renderer>().material.color = LoopPartColor;
                ThalamusLeft.GetComponent<Renderer>().material.color = LoopPartColor;
                PutamenRight.GetComponent<Renderer>().material.color = LoopPartColor;
                PutamenLeft.GetComponent<Renderer>().material.color = LoopPartColor;
                CortexLeft.GetComponent<Renderer>().material.color = LoopPartColor;
                CortexRight.GetComponent<Renderer>().material.color = LoopPartColor;
                //Globus Pallidus also part of loop
                GlobusBrainLeft.GetComponent<Renderer>().material.color = LoopPartColor;
                GlobusBrainRight.GetComponent<Renderer>().material.color = LoopPartColor;
                NucleusButton.SetActive(false);
                SubtantiaButton.SetActive(false);
                GlobusButton.SetActive(false);
                GlobusDBSButton.SetActive(false);
                NucleusDBSButton.SetActive(false); 
                BasalButton.SetActive(true);
                ThalamusButton.SetActive(true);
                CortexButton.SetActive(true);
                PutamenLeft.GetComponent<Outline>().enabled = true;
                PutamenRight.GetComponent<Outline>().enabled = true;
                ThalamusLeft.GetComponent<Outline>().enabled = true;
                ThalamusRight.GetComponent<Outline>().enabled = true;
                CortexRight.GetComponent<Outline>().enabled = true;
                CortexLeft.GetComponent<Outline>().enabled = true;
                foreach (GameObject electrode in ElectrodeGP)
                {
                    electrode.SetActive(false);
                }
                foreach (GameObject electrode in ElectrodeSTN)
                {
                    electrode.SetActive(false);
                }
                PutamenLeft.GetComponent<MotorLoopBehavior>().looping = true;
                //TotalBrain.GetComponent<MotorLoopBehavior>().looping = true;
                //this.GetComponent<MotorLoopBehavior>().looping = true;
                break;
            default:
                break;
        }
    }
    public void SwitchMode()
    {
        if (current == AppState.Information)
        {
            current = AppState.Loop;
            ModusButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Loop";
        }
        else if (current == AppState.DBS)
        {
            current = AppState.Information;
            ModusButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Information";
        }
        else
        {
            current = AppState.DBS;
            ModusButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "DBS";
        }
    }

    public void SetTextNucleus()
    {
        InfoText.GetComponent<TextMesh>().text = "Der Nucleus subthalamicus ist bei Parkinson\n " +
            "überaktiv und löst primär das Zittern/ \n" +
            "Ruhetremor aus. Durch die Krankheit wird der \n" +
            "Thalamus gehemmt, was die Anregung des \n Motorcortex (gibt Bewegungsbefehle an\n Muskeln) weniger wahrscheinlich macht.";
        DeactivateAllOutlines();
        NucleusBrainLeft.GetComponent<Outline>().enabled = true;
        NucleusBrainRight.GetComponent<Outline>().enabled = true;
    }
    public void SetTextSubtantia()
    {
        InfoText.GetComponent<TextMesh>().text = "Die Substantia nigra liegt nahe dem \n Hirnstamm, welcher auf Bewegungen berechnet " +
            "und einleitet. Die Stelle reagiert auf \n Dopamin um richtig zu funktionieren. Die" +
            " Substantia Nigra besteht z.T. aus dopamin-\n liefernden Nerven, welche bei Parkinson \n" +
            " absterben. Sie ist die Stelle im Kopf, die \n am stärksten betroffen ist.";
        DeactivateAllOutlines();
        SubtantiaBrainLeft.GetComponent<Outline>().enabled = true;
        SubtantiaBrainRight.GetComponent<Outline>().enabled = true;
    }
    public void SetTextGlobus()
    {
        InfoText.GetComponent<TextMesh>().text = "Der Globus pallidus ist ein weiteres \n " +
            "Nervenzentrum für Balance, Bewegung und \n Laufen. Eine Unterversorgung dieses Bereiches \n" +
            "beispielsweise aufgrund der Parkinson- \n erkrankung, z.B. mit Dopamin, führt zu \n" +
            "einer gestörten Funktionalität.";
        DeactivateAllOutlines();
        GlobusBrainLeft.GetComponent<Outline>().enabled = true;
        GlobusBrainRight.GetComponent<Outline>().enabled = true;
    }
    public void SetTextNucleusDBS()
    {
        InfoText.GetComponent<TextMesh>().text = "Für eine Therapie mit der Tiefenhirnstimulation\n " +
            "wird oft der subthalamische Nucleus gewählt.\n Da dieser durch die Erkrankung überaktiv ist \n" +
            "und Impulse diese Fehlfunktion wesentlich \n reduzieren können.";
        DeactivateAllOutlines();
        NucleusBrainLeft.GetComponent<Outline>().enabled = true;
        NucleusBrainRight.GetComponent<Outline>().enabled = true;
        foreach (GameObject electrode in ElectrodeGP)
        {
            electrode.GetComponent<electrodeBehavior>().specular = false;
            electrode.GetComponent<electrodeBehavior>().lightUp = false;
        }
        foreach (GameObject electrode in ElectrodeSTN)
        {
            electrode.GetComponent<electrodeBehavior>().CurrentLightIndex = 1;
            electrode.GetComponent<electrodeBehavior>().specular = true;
            //problem: kick out following 2 lines does nithing
            electrode.GetComponent<electrodeBehavior>().lightUp = true;
            //electrode.GetComponent<electrodeBehavior>().StartGlowing();
        }
        ///** maybe not necessary By just using lightup t/f
        electrodeLights = GameObject.FindGameObjectsWithTag("ElectrodeLight");
        foreach (GameObject electrodeLight in electrodeLights)
        {
            electrodeLight.GetComponent<Light>().enabled = false;
            //electrodeLight.SetActive(false);
            //electrodeLight.GetComponentInChildren<Light>().enabled = false;
        }
        electrodeLightsSTN = GameObject.FindGameObjectsWithTag("ElectrodeLightSTN");
        foreach (GameObject electrodeLight in electrodeLightsSTN)
        {
            electrodeLight.GetComponent<Light>().enabled = false;
            //electrodeLight.SetActive(true);
            //electrodeLight.GetComponentInChildren<Light>().enabled = true;
        }
    }
    public void SetTextGlobusDBS()
    {
        InfoText.GetComponent<TextMesh>().text = "Der Globus pallidus wird bei der Tiefenhirn-\n " +
            "stimulation in der Spätphase der Erkrankung \n genutzt. Elektrische Impulse führen dort zu \n" +
            "einer Synchornisation des gestörten \n Verhaltens und lindern so Symptome.";
        DeactivateAllOutlines();
        GlobusBrainLeft.GetComponent<Outline>().enabled = true;
        GlobusBrainRight.GetComponent<Outline>().enabled = true;
        electrodeLights = GameObject.FindGameObjectsWithTag("ElectrodeLight");
        foreach (GameObject electrodeLight in electrodeLights)
        {
            electrodeLight.GetComponent<Light>().enabled = false;
            //electrodeLight.SetActive(true);
        }
        electrodeLightsSTN = GameObject.FindGameObjectsWithTag("ElectrodeLightSTN");
        foreach (GameObject electrodeLight in electrodeLightsSTN)
        {
            electrodeLight.GetComponent<Light>().enabled = false;
            //electrodeLight.SetActive(false);
        }
        foreach (GameObject electrode in ElectrodeSTN)
        {
            electrode.GetComponent<electrodeBehavior>().specular = false;
            electrode.GetComponent<electrodeBehavior>().lightUp = false;
        }
        foreach (GameObject electrode in ElectrodeGP)
        {
            //electrode.SetActive(true);
            electrode.GetComponent<electrodeBehavior>().CurrentLightIndex = 1;
            electrode.GetComponent<electrodeBehavior>().specular = true;
            electrode.GetComponent<electrodeBehavior>().lightUp = true;
            //electrode.GetComponent<electrodeBehavior>().StartGlowing();
            //wrong postion?? later ? electrode.GetComponent<electrodeBehavior>().ElectrodeActive();
            //this line does not do anything
        }
        

    }
    public void SetTextLoops()
    {
        InfoText.GetComponent<TextMesh>().text = "Die hauptsächlich betroffenen Bereiche \n bei Parkinson sind Teil der sogenannten \n" +
            "Basal Ganglien, ein Komplex im Hirn, der \n ungewollte Bewegungen unterbindet und  \n" +
            "gewollte auslöst. Das passiert durch \n Aktivierung bestimmter Areale in der hier \n" +
            "dargestellten fortlaufenden Schleife. \n Parkinson behindert den richtigen Ablauf \n" +
            "und erzeugt so die bekannten Symptome.";
        DeactivateAllOutlines();
    }
        public void DeactivateAllOutlines()
    {
        GlobusBrainLeft.GetComponent<Outline>().enabled = false;
        GlobusBrainRight.GetComponent<Outline>().enabled = false;
        SubtantiaBrainLeft.GetComponent<Outline>().enabled = false;
        SubtantiaBrainRight.GetComponent<Outline>().enabled = false;
        NucleusBrainLeft.GetComponent<Outline>().enabled = false;
        NucleusBrainRight.GetComponent<Outline>().enabled = false;
        PutamenLeft.GetComponent<Outline>().enabled = false;
        PutamenRight.GetComponent<Outline>().enabled = false;
        ThalamusLeft.GetComponent<Outline>().enabled = false;
        ThalamusRight.GetComponent<Outline>().enabled = false;
        CortexRight.GetComponent<Outline>().enabled = false;
        CortexLeft.GetComponent<Outline>().enabled = false;
    }
}

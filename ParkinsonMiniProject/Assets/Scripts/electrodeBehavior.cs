using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* *
 * Glowing behavior of electrode for DBS
 * */

public class electrodeBehavior : MonoBehaviour
{
    public bool specular;
    GameObject[] electrodeLights;
    GameObject[] electrodeLightsSTN;
    GameObject electrodeLight;
    int counter = 0;
    public bool lightUp;
    float starting = 000001f;
    float repeating = 0.2f;

    void Start()
    {
        specular = false;
        electrodeLights = GameObject.FindGameObjectsWithTag("ElectrodeLight");
        electrodeLightsSTN = GameObject.FindGameObjectsWithTag("ElectrodeLightSTN");
        foreach (GameObject electrodeLight in electrodeLights)
        {
            electrodeLight.GetComponent<Light>().enabled = false;
        }
        foreach (GameObject electrodeLight in electrodeLightsSTN)
        {
            electrodeLight.GetComponent<Light>().enabled = false;
        }
        if (lightUp)
        {
            Debug.Log("lightUp set true from start");
            //Invokes the method methodName in time seconds, then repeatedly every repeatRate seconds.
            InvokeRepeating("ElectrodeActive", starting, repeating);
        }
    }

    // Update is called once per frame
    void Update()
    {
        LightUp();
        LightOff();
    }
    void LightUp()
    {
        if (specular)
        {
            MeshRenderer[] components= GetComponentsInChildren<MeshRenderer>();
            //Get the mesh renderer
            MeshRenderer m_Renderer = GetComponent<MeshRenderer>();

            //Get the specular shader
            Shader m_Specular = Shader.Find("Legacy Shaders/Self-Illumin/Specular");

            //Apply the shader
            if (m_Specular)
            {
                m_Renderer.material.shader = m_Specular;
                foreach (MeshRenderer component in components)
                {
                    component.material.shader = m_Specular;
                }
            }
            else
                Debug.Log("Check shader name");

            //Assign shader values....
        }
    }
    void LightOff()
    {
        if (!specular)
        {
            //Get the mesh renderer
            MeshRenderer m_Renderer = GetComponent<MeshRenderer>();
            MeshRenderer[] components = gameObject.GetComponentsInChildren<MeshRenderer>();
            //Get the specular shader
            Shader m_Standard = Shader.Find("Standard");

            //Apply the shader
            if (m_Standard)
            {
                m_Renderer.material.shader = m_Standard;
                foreach (MeshRenderer component in components)
                {
                    component.material.shader = m_Standard;
                }
            } 
            else
                Debug.Log("Check shader name");

            //Assign shader values....
        }
    }

    public void StartGlowing()
    {
        InvokeRepeating("ElectrodeActive", starting, repeating);
    }

    //let spotlights light up after each other
    public void ElectrodeActive()
    {
        //ist bei allen immer an, wenn man Funktionalität überhaupt will
        //und alle fangen an zu leuchtenn
        //Fallunterscheidung notwendig
        string electrodeOn = this.gameObject.tag;
        if (lightUp)
        {   
            Debug.Log("ElectrodeActive called");
            int noOfLights = electrodeLights.Length;
            int noOfLightsSTN = electrodeLightsSTN.Length;
            
            if (counter == 0)
            {   if (electrodeOn == "electrodeGP")
                {
                    foreach (GameObject electrodeLight in electrodeLights)
                    {
                        electrodeLight.GetComponent<Light>().enabled = false;
                    }
                } else if (electrodeOn == "electrodeSTN"){
                    foreach (GameObject electrodeLight in electrodeLightsSTN)
                    {
                        electrodeLight.GetComponent<Light>().enabled = false;
                    }
                }
                counter++;
            }
            else if (counter <= noOfLights || counter <= noOfLightsSTN)
            {   if (electrodeOn == "electrodeGP")
                {
                    electrodeLights[counter - 1].GetComponent<Light>().enabled = true;
                    electrodeLights[counter - 1].GetComponent<Light>().enabled = true;
                }
                else if (electrodeOn == "electrodeSTN")
                {
                    electrodeLightsSTN[counter - 1].GetComponent<Light>().enabled = true;
                    
                    electrodeLightsSTN[counter - 1].GetComponent<Light>().enabled = true;
                }
                counter++;
            }
            else if (counter > noOfLights || counter > noOfLightsSTN)
            {
                counter = 0;
            }
        }
        else
        {
            counter = 0;
            Debug.Log("lightUp set false");
            /**
            foreach (GameObject electrodeLight in electrodeLights)
            {
                electrodeLight.GetComponent<Light>().enabled = false;
            }
            foreach (GameObject electrodeLight in electrodeLightsSTN)
            {
                electrodeLight.GetComponent<Light>().enabled = false;
            }*/
        }
    }
}

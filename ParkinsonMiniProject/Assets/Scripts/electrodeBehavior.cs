using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* *
 * Glowing behavior of electrode for DBS
 * */

public class electrodeBehavior : MonoBehaviour
{
    public bool specular;
    void Start()
    {
        specular = false;
    }

    // Update is called once per frame
    void Update()
    {
        LightUp();
        LightDown();
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
    void LightDown()
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
}

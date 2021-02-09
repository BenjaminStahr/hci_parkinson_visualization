using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayInfoText : MonoBehaviour
{
    public GameObject PlayThis; 
    public GameObject Disabled1;
    public GameObject Disabled2;
    public GameObject Disabled3;
    public GameObject Disabled4;
    public GameObject Disabled5;
    public GameObject Disabled6;
    GameObject currentButton;
    public string buttonText;

    public void PlayInfo()
    {
        Disabled1.GetComponent<AudioSource>().Stop();
        Disabled2.GetComponent<AudioSource>().Stop();
        Disabled3.GetComponent<AudioSource>().Stop();
        Disabled4.GetComponent<AudioSource>().Stop();
        Disabled5.GetComponent<AudioSource>().Stop();
        PlayThis.GetComponent<AudioSource>().Play();
    }

    public void ModusAndAudio()
    {
        //gucken ob das funktioniert ->bei mir werden die neuen public gameobjects im inspector nicht geupdatet...
        currentButton = GameObject.FindGameObjectWithTag("Modus");
        buttonText = currentButton.GetComponentInChildren<TextMeshProUGUI>().text;
        if (buttonText == "Loop")
            PlayInfo();
        else
            StopAll();
    }

    public void StopAll()
    {
        Disabled1.GetComponent<AudioSource>().Stop();
        Disabled2.GetComponent<AudioSource>().Stop();
        Disabled3.GetComponent<AudioSource>().Stop();
        Disabled4.GetComponent<AudioSource>().Stop();
        Disabled5.GetComponent<AudioSource>().Stop();
        Disabled6.GetComponent<AudioSource>().Stop();
    }
}

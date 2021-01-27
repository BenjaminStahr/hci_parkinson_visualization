using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInfoText : MonoBehaviour
{
    public GameObject PlayThis;
    public GameObject Disabled1;
    public GameObject Disabled2;
    public GameObject Disabled3;
    public GameObject Disabled4;

    public void PlayInfo()
    {
        Disabled1.GetComponent<AudioSource>().Stop();
        Disabled2.GetComponent<AudioSource>().Stop();
        Disabled3.GetComponent<AudioSource>().Stop();
        Disabled4.GetComponent<AudioSource>().Stop();
        PlayThis.GetComponent<AudioSource>().Play();
    }

    //hier könnte ich dann noch eine Funktion schreiben, die sämtliche restliche AudioSources deaktiviert
}

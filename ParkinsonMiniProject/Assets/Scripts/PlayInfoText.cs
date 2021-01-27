using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInfoText : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSourceToBeDisabled1;
    public AudioSource audioSourceToBeDisabled2;
    public AudioSource audioSourceToBeDisabled3;
    public AudioSource audioSourceToBeDisabled4;

    public void PlayInfo()
    {
        audioSourceToBeDisabled1.Stop();
        audioSourceToBeDisabled2.Stop();
        audioSourceToBeDisabled3.Stop();
        audioSourceToBeDisabled4.Stop();
        audioSource.Play();
        
    }

    //hier könnte ich dann noch eine Funktion schreiben, die sämtliche restliche AudioSources deaktiviert
}

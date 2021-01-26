using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInfoText : MonoBehaviour
{
    public AudioSource audioSource;

    public void PlayInfo()
    {
        audioSource.Play();
    }
}

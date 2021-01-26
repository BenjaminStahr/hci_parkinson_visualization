using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoTextClick : MonoBehaviour, IPointerClickHandler
{
    //add callbacks in the inspector like for buttons
    //public UnityEvent onClick;

    public AudioSource audioSourceGlobus;
    public AudioSource audioSourceNucleus;
    public AudioSource audioSourceSubstantia;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //hier muss dann der Text vorgelesen werden
        audioSourceGlobus.Play();

        //invoke your event
        //onClick.Invoke();
    }
}

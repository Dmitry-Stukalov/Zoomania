using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sound_Script: MonoBehaviour, IPointerClickHandler
{
    public AudioSource Audio;

    public void OnPointerClick(PointerEventData data)
	{
		Audio.Play();
	}
}

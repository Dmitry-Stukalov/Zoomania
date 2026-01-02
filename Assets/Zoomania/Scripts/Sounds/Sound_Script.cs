using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sound_Script: MonoBehaviour, IPointerDownHandler
{
    public AudioSource Audio;

    public void OnPointerDown(PointerEventData data)
	{
		Audio.Play();
	}
}

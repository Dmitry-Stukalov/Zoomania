using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MuteSound : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData data)
	{
        foreach (var audio in GameObject.FindGameObjectsWithTag("Audio"))
        {
            audio.GetComponent<AudioSource>().mute = true;
        }
	}
}

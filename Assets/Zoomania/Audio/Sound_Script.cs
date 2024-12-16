using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Background : MonoBehaviour, IPointerClickHandler
{
    public AudioSource Audio;

    public void OnPointerClick(PointerEventData data)
	{
		Audio.Play();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MuteMusic : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData data)
	{
		GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().mute = true;
	}
}

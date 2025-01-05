using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mute_UnMute_Music : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private Sprite Mute { get; set; }
	[field: SerializeField] private Sprite UnMute { get; set; }
	private bool IsMute { get; set; } = false;

	void Start()
	{
		gameObject.GetComponent<Image>().sprite = UnMute;
	}

	public void OnPointerClick(PointerEventData data)
	{
		if (!IsMute)
		{
			GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().mute = true;

			gameObject.GetComponent<Image>().sprite = Mute;

			IsMute = true;
		}
		else
		{
			GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().mute = false;

			gameObject.GetComponent<Image>().sprite = UnMute;

			IsMute = false;
		}
	}
}

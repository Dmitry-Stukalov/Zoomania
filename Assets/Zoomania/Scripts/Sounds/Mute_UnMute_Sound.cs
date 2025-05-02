using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mute_UnMute_Sound : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private Sprite Mute {  get; set; }
	[field: SerializeField] private Sprite UnMute { get; set; }
	private bool IsMute { get; set; } = false;
	private Image image { get; set; }

	void Start()
	{
		image = GetComponent<Image>();
		image.sprite = UnMute;
	}

	public void OnPointerClick(PointerEventData data)
	{
		if (!IsMute)
		{
			foreach (var audio in GameObject.FindGameObjectsWithTag("Audio"))
				audio.GetComponent<AudioSource>().mute = true;

			image.sprite = Mute;

			IsMute = true;
		}
		else
		{
			foreach (var audio in GameObject.FindGameObjectsWithTag("Audio")) 
				audio.GetComponent<AudioSource>().mute = false;

			image.sprite = UnMute;

			IsMute = false;
		}
	}
}
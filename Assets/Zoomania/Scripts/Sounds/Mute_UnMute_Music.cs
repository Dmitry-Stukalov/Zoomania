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
			GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().mute = true;

			image.sprite = Mute;

			IsMute = true;
		}
		else
		{
			GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().mute = false;

			image.sprite = UnMute;

			IsMute = false;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mute_UnMute_Music : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private Sprite Mute { get; set; }
	[field: SerializeField] private Sprite UnMute { get; set; }
	private List<AudioSource> MusicList = new List<AudioSource>();
	private bool IsMute { get; set; } = false;
	private Image image { get; set; }

	void Start()
	{
		image = GetComponent<Image>();
		image.sprite = UnMute;

		foreach (var music in GameObject.FindGameObjectsWithTag("Music"))
		{
			MusicList.Add(music.GetComponent<AudioSource>());
		}
	}

	public void OnPointerClick(PointerEventData data)
	{
		if (!IsMute)
		{

			for (int i = 0; i < MusicList.Count; i++) MusicList[i].mute = true;

			image.sprite = Mute;

			IsMute = true;
		}
		else
		{
			for (int i = 0; i < MusicList.Count; i++) MusicList[i].mute = false;

			image.sprite = UnMute;

			IsMute = false;
		}
	}
}

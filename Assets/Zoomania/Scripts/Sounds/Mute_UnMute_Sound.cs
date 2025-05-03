using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mute_UnMute_Sound : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private Sprite Mute {  get; set; }
	[field: SerializeField] private Sprite UnMute { get; set; }
	private List<AudioSource> SoundList = new List<AudioSource>();
	private Barn barn { get; set; }
	private bool IsMute { get; set; } = false;
	private Image image { get; set; }

	void Start()
	{
		image = GetComponent<Image>();
		image.sprite = UnMute;

		foreach (var music in GameObject.FindGameObjectsWithTag("Audio"))
		{
			SoundList.Add(music.GetComponent<AudioSource>());
		}

		barn = GameObject.FindGameObjectWithTag("Barn").GetComponent<Barn>();
		barn.Spawn += AddSound;
	}

	private void AddSound()
	{
		SoundList.Clear();

		foreach (var music in GameObject.FindGameObjectsWithTag("Audio"))
		{
			SoundList.Add(music.GetComponent<AudioSource>());
		}
		
		if (IsMute) for (int i = 0; i < SoundList.Count; i++) SoundList[i].mute = true;
		else for (int i = 0; i < SoundList.Count; i++) SoundList[i].mute = false;
	}

	public void OnPointerClick(PointerEventData data)
	{
		if (!IsMute)
		{
			for (int i = 0; i < SoundList.Count; i++) SoundList[i].mute = true;

			image.sprite = Mute;

			IsMute = true;
		}
		else
		{
			for (int i = 0; i < SoundList.Count; i++) SoundList[i].mute = false;

			image.sprite = UnMute;

			IsMute = false;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Panda_Description : MonoBehaviour
{
	[field: SerializeField] private GameObject AnimalPlace {  get; set; }
	private Animals_New Panda {  get; set; }
	private TextMeshPro Text { get; set; }
	private bool Information { get; set; }


	public void Start()
	{
		Information = false;

		Text = GetComponentInChildren<TextMeshPro>();

		Text.text = "Уровень: -\nДоход за клик: -";
	}

	public void SetInformaion()
	{
		if (Information)
		{
			Information = false;

			Text.text = "Уровень: -\nДоход за клик: -";
		}
		else
		{
			Information = true;
			Panda = AnimalPlace.GetComponentInChildren<Animals_New>();

			Text.text = $"Уровень: {Panda.CurrentLevel.CurrentLevelNumber}\nДоход за клик: {Panda.CurrentLevel.MoneyPerClick}";
		}
	}
}

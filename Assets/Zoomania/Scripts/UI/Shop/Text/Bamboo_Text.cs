using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bamboo_Text : MonoBehaviour
{
	private GameObject Building { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private Buy_Bamboo Bamboo { get; set; }

	public void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();

		Building = GameObject.FindGameObjectWithTag("Background");
		Bamboo = Building.GetComponent<Buy_Bamboo>();

		UpdateData();
		Bamboo.OnUpgrade += UpdateData;
	}

	public void UpdateData()
	{
		if (Bamboo.NextLevelData() == null)
		{
			Text.text = $"Уровень max: {Bamboo.CurrentLevel.CurrentLevelNumber}\n";
		}
		else
		{
			Text.text = $"Уровень {Bamboo.CurrentLevel.CurrentLevelNumber} -> {Bamboo.NextLevelData().CurrentLevelNumber}\n";
		}
	}
}

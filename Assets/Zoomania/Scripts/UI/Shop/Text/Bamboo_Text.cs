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

		Text.text = $"”ровень 0 -> 1\n";
		Text.text += $"Ёффективность кликов +0 -> +0.1\n";

		Bamboo.OnUpgrade += UpdateData;
	}

	public void UpdateData()
	{
		if (Bamboo.CurrentLevel.CurrentLevelNumber == 7)
		{
			Text.text = $"”ровень max: {Bamboo.CurrentLevel.CurrentLevelNumber}\n";
			Text.text += $"Ёффективность кликов: +{Bamboo.CurrentLevel.EffectValue}\n";
		}
		else
		{
			Text.text = $"”ровень {Bamboo.CurrentLevel.CurrentLevelNumber} -> {Bamboo.NextLevelData().CurrentLevelNumber}\n";
			Text.text += $"Ёффективность кликов +{Bamboo.CurrentLevel.EffectValue} -> +{Bamboo.NextLevelData().EffectValue}\n";
		}
	}
}

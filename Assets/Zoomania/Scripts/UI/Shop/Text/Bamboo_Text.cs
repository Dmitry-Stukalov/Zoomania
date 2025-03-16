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
		if (Bamboo.CurrentLevelData().CurrentLevelNumber == 7)
		{
			Text.text = $"”ровень max: {Bamboo.CurrentLevelData().CurrentLevelNumber}\n";
			Text.text += $"Ёффективность кликов: +{Bamboo.CurrentLevelData().EffectValue}\n";
		}
		else
		{
			Text.text = $"”ровень {Bamboo.CurrentLevelData().CurrentLevelNumber} -> {Bamboo.NextLevelData().CurrentLevelNumber}\n";
			Text.text += $"Ёффективность кликов +{Bamboo.CurrentLevelData().EffectValue} -> +{Bamboo.NextLevelData().EffectValue}\n";
		}
	}
}

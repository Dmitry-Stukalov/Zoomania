using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bamboo_Text : ShopTextBase
{
	private Buy_Bamboo Bamboo { get; set; }

	protected override void Start()
	{
		base.Start();

		Bamboo = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Bamboo>();

		Bamboo.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (Bamboo.CurrentLevelData().CurrentLevelNumber == Bamboo.GetLevelsCount() - 1)
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

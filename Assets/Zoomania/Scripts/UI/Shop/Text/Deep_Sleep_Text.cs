using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Deep_Sleep_Text : ShopTextBase
{
	private Deep_Sleep Sleep { get; set; }

	protected override void Start()
	{
		base.Start();

		Sleep = GameObject.FindGameObjectWithTag("EssenceClick").GetComponent<Deep_Sleep>();

		Sleep.OnUpgrade += UpdateData;

		UpdateData();

	}

	protected override void UpdateData()
	{
		if (Sleep.CurrentLevelData().CurrentLevelNumber == Sleep.GetLevelsCount() - 1)
		{
			Text.text = $"”ровень max: {Sleep.CurrentLevelData().CurrentLevelNumber}\n";
			Text.text += $"Ёффективность кликов: +{Sleep.CurrentLevelData().EffectValue}\n";
		}
		else
		{
			Text.text = $"”ровень {Sleep.CurrentLevelData().CurrentLevelNumber} -> {Sleep.NextLevelData().CurrentLevelNumber}\n";
			Text.text += $"Ёффективность кликов +{Sleep.CurrentLevelData().EffectValue} -> +{Sleep.NextLevelData().EffectValue}\n";
		}
	}
}

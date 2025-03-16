using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Water_Speed_Text : ShopTextBase
{
	private ResourceBuilding WaterBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<ResourceBuilding>();

		WaterBuilding.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (WaterBuilding.CurrentImproveLevel.CurrentLevelNumber == WaterBuilding.GetLevelsCount())
		{
			Text.text = $"Уровень max: {WaterBuilding.CurrentImproveLevel.CurrentLevelNumber}\n";

			Text.text += $"Время получаемой воды: {WaterBuilding.CurrentImproveLevel.EffectValue} сек";
		}
		else
		{
			Text.text = $"Уровень {WaterBuilding.CurrentImproveLevel.CurrentLevelNumber} -> {WaterBuilding.NextLevelTimerData().CurrentLevelNumber}\n";

			Text.text += $"Время получаемой воды: {WaterBuilding.CurrentImproveLevel.EffectValue} сек -> {WaterBuilding.NextLevelTimerData().EffectValue} сек";
		}
	}
}

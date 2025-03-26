using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Water_Speed_Text : ShopTextBase
{
	private WaterBuildingTimer WaterBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<WaterBuildingTimer>();

		WaterBuilding.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (WaterBuilding.CurrentLevelData().CurrentLevelNumber == WaterBuilding.GetLevelsCount())
		{
			Text.text = $"Уровень max: {WaterBuilding.CurrentLevelData().CurrentLevelNumber}\n";

			Text.text += $"Время получаемой воды: {WaterBuilding.CurrentLevelData().EffectValue} сек";
		}
		else
		{
			Text.text = $"Уровень {WaterBuilding.CurrentLevelData().CurrentLevelNumber} -> {WaterBuilding.NextLevelData().CurrentLevelNumber}\n";

			Text.text += $"Время получаемой воды: {WaterBuilding.CurrentLevelData().EffectValue} сек -> {WaterBuilding.NextLevelData().EffectValue} сек";
		}
	}
}

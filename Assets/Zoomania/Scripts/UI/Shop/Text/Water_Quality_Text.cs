using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Water_Quality_Text : ShopTextBase
{
	private WaterBuildingValue WaterBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<WaterBuildingValue>();

		WaterBuilding.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (WaterBuilding.CurrentLevel.CurrentLevelNumber == WaterBuilding.GetLevelsCount())
		{
			Text.text = $"Уровень max: {WaterBuilding.CurrentLevelData().CurrentLevelNumber}\n";
			Text.text += $"Количество получаемых ресурсов: {WaterBuilding.CurrentLevelData().IncomePerSecondValue}\n";
			Text.text += $"Количество ресурсов для кормления: {WaterBuilding.CurrentLevelData().DragResourceCapacity}\n";
		}
		else
		{
			Text.text = $"Уровень {WaterBuilding.CurrentLevelData().CurrentLevelNumber} -> {WaterBuilding.NextLevelData().CurrentLevelNumber}\n";
			Text.text += $"Количество получаемых ресурсов {WaterBuilding.CurrentLevelData().IncomePerSecondValue} -> {WaterBuilding.NextLevelData().IncomePerSecondValue}\n";
			Text.text += $"Количество ресурсов для кормления {WaterBuilding.CurrentLevelData().DragResourceCapacity} -> {WaterBuilding.NextLevelData().DragResourceCapacity}\n";
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Water_Quality_Text : ShopTextBase
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
		if (WaterBuilding.CurrentLevel.CurrentLevelNumber == WaterBuilding.GetLevelsCount())
		{
			Text.text = $"Уровень max: {WaterBuilding.CurrentLevel.CurrentLevelNumber}\n";
			Text.text += $"Количество получаемых ресурсов: {WaterBuilding.CurrentLevel.IncomePerSecondValue}\n";
			Text.text += $"Количество ресурсов для кормления: {WaterBuilding.CurrentLevel.DragResourceCapacity}\n";
		}
		else
		{
			Text.text = $"Уровень {WaterBuilding.CurrentLevel.CurrentLevelNumber} -> {WaterBuilding.NextLevelValueData().CurrentLevelNumber}\n";
			Text.text += $"Количество получаемых ресурсов {WaterBuilding.CurrentLevel.IncomePerSecondValue} -> {WaterBuilding.NextLevelValueData().IncomePerSecondValue}\n";
			Text.text += $"Количество ресурсов для кормления {WaterBuilding.CurrentLevel.DragResourceCapacity} -> {WaterBuilding.NextLevelValueData().DragResourceCapacity}\n";
		}
	}
}

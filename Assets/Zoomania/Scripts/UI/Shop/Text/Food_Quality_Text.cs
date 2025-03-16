using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food_Quality_Text : ShopTextBase
{
	private ResourceBuilding FoodBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		FoodBuilding = GameObject.FindGameObjectWithTag("FoodBuilding").GetComponent<ResourceBuilding>();

		FoodBuilding.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (FoodBuilding.CurrentLevel.CurrentLevelNumber == FoodBuilding.GetLevelsCount())
		{
			Text.text = $"Уровень max: {FoodBuilding.CurrentLevel.CurrentLevelNumber}\n";
			Text.text += $"Количество получаемых ресурсов: {FoodBuilding.CurrentLevel.IncomePerSecondValue}\n";
			Text.text += $"Количество ресурсов для кормления: {FoodBuilding.CurrentLevel.DragResourceCapacity}\n";
		}
		else
		{
			Text.text = $"Уровень {FoodBuilding.CurrentLevel.CurrentLevelNumber} -> {FoodBuilding.NextLevelValueData().CurrentLevelNumber}\n";
			Text.text += $"Количество получаемых ресурсов {FoodBuilding.CurrentLevel.IncomePerSecondValue} -> {FoodBuilding.NextLevelValueData().IncomePerSecondValue}\n";
			Text.text += $"Количество ресурсов для кормления {FoodBuilding.CurrentLevel.DragResourceCapacity} -> {FoodBuilding.NextLevelValueData().DragResourceCapacity}\n";
		}
	}
}

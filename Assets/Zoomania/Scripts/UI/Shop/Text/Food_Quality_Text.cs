using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food_Quality_Text : ShopTextBase
{
	private FoodBuildingValue FoodBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		FoodBuilding = GameObject.FindGameObjectWithTag("NewFood").GetComponent<FoodBuildingValue>();

		FoodBuilding.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (FoodBuilding.CurrentLevelData().CurrentLevelNumber == FoodBuilding.GetLevelsCount())
		{
			Text.text = $"Уровень max: {FoodBuilding.CurrentLevelData().CurrentLevelNumber}\n";
			Text.text += $"Количество получаемых ресурсов: {FoodBuilding.CurrentLevelData().IncomePerSecondValue}\n";
			Text.text += $"Количество ресурсов для кормления: {FoodBuilding.CurrentLevelData().DragResourceCapacity}\n";
		}
		else
		{
			Text.text = $"Уровень {FoodBuilding.CurrentLevelData().CurrentLevelNumber} -> {FoodBuilding.NextLevelData().CurrentLevelNumber}\n";
			Text.text += $"Количество получаемых ресурсов {FoodBuilding.CurrentLevelData().IncomePerSecondValue} -> {FoodBuilding.NextLevelData().IncomePerSecondValue}\n";
			Text.text += $"Количество ресурсов для кормления {FoodBuilding.CurrentLevelData().DragResourceCapacity} -> {FoodBuilding.NextLevelData().DragResourceCapacity}\n";
		}
	}
}

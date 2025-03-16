using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food_Speed_Text : ShopTextBase
{
	private ResourceBuilding FoodBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		FoodBuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<ResourceBuilding>();

		FoodBuilding.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (FoodBuilding.CurrentLevel.CurrentLevelNumber == FoodBuilding.GetLevelsCount())
		{
			Text.text = $"Уровень max: {FoodBuilding.CurrentImproveLevel.CurrentLevelNumber}\n";

			Text.text += $"Время получаемой еды: {FoodBuilding.CurrentImproveLevel.EffectValue} сек";
		}
		else
		{
			Text.text = $"Уровень {FoodBuilding.CurrentImproveLevel.CurrentLevelNumber} -> {FoodBuilding.NextLevelTimerData().CurrentLevelNumber}\n";

			Text.text += $"Время получаемой еды: {FoodBuilding.CurrentImproveLevel.EffectValue} сек -> {FoodBuilding.NextLevelTimerData().EffectValue} сек";
		}
	}
}

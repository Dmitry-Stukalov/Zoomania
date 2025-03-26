using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food_Speed_Text : ShopTextBase
{
	private FoodBuildingTimer FoodBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		FoodBuilding = GameObject.FindGameObjectWithTag("NewFood").GetComponent<FoodBuildingTimer>();

		FoodBuilding.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (FoodBuilding.CurrentLevelData().CurrentLevelNumber == FoodBuilding.GetLevelsCount())
		{
			Text.text = $"Уровень max: {FoodBuilding.CurrentLevelData().CurrentLevelNumber}\n";

			Text.text += $"Время получаемой еды: {FoodBuilding.CurrentLevelData().EffectValue} сек";
		}
		else
		{
			Text.text = $"Уровень {FoodBuilding.CurrentLevelData().CurrentLevelNumber} -> {FoodBuilding.NextLevelData().CurrentLevelNumber}\n";

			Text.text += $"Время получаемой еды: {FoodBuilding.CurrentLevelData().EffectValue} сек -> {FoodBuilding.NextLevelData().EffectValue} сек";
		}
	}
}

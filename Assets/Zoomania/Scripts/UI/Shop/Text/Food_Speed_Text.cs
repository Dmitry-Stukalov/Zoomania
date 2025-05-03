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
		LevelNumber.text = FoodBuilding.CurrentLevelData().CurrentLevelNumber.ToString();

		Text.text = $"≈да каждые: {FoodBuilding.CurrentLevelData().EffectValue} сек";
	}
}

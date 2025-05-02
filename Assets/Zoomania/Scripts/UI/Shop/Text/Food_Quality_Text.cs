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
		LevelNumber.text = FoodBuilding.CurrentLevelData().CurrentLevelNumber.ToString();

		Text.text = $"Получаемая еда: {FoodBuilding.CurrentLevelData().IncomePerSecondValue}\n";
		Text.text += $"Еда при кормлении: {FoodBuilding.CurrentLevelData().DragResourceCapacity}\n";
	}
}

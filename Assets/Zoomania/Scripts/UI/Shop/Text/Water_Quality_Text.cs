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
		LevelNumber.text = WaterBuilding.CurrentLevelData().CurrentLevelNumber.ToString();

		Text.text = $"Получаемая вода: {WaterBuilding.CurrentLevelData().IncomePerSecondValue}\n";
		Text.text += $"Вода при кормлении: {WaterBuilding.CurrentLevelData().DragResourceCapacity}\n";
	}
}

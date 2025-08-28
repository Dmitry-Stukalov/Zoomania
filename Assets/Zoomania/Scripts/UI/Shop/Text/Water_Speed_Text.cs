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
		LevelNumber.text = WaterBuilding.CurrentLevelData().CurrentLevelNumber.ToString();

		Text.text = $"Вода каждые: {WaterBuilding.CurrentLevelData().EffectValue} сек";
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Water_Speed_Text : MonoBehaviour
{
	private GameObject Building { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private ResourceBuilding WaterBuilding { get; set; }

	public void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();

		Building = GameObject.FindGameObjectWithTag("WaterBuilding");
		WaterBuilding = Building.GetComponent<ResourceBuilding>();

		//UpdateData();
		WaterBuilding.OnUpgrade += UpdateData;
	}

	public void UpdateData()
	{
		if (WaterBuilding.CurrentImproveLevel.CurrentLevelNumber == WaterBuilding.GetLevelsCount())
		{
			Text.text = $"Уровень max: {WaterBuilding.CurrentImproveLevel.CurrentLevelNumber}\n";

			Text.text += $"Время получаемой воды: {WaterBuilding.CurrentImproveLevel.EffectValue} сек";
		}
		else
		{
			Text.text = $"Уровень {WaterBuilding.CurrentImproveLevel.CurrentLevelNumber} -> {WaterBuilding.NextLevelTimerData().CurrentLevelNumber}\n";

			Text.text += $"Время получаемой воды: {WaterBuilding.CurrentImproveLevel.EffectValue} сек -> {WaterBuilding.NextLevelTimerData().EffectValue} сек";
		}
	}
}

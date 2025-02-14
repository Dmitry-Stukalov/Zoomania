using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Water_Quality_Text : MonoBehaviour
{
	private GameObject Building { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private ResourceBuilding WaterBuilding { get; set; }

	public void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();

		Building = GameObject.FindGameObjectWithTag("WaterBuilding");
		WaterBuilding = Building.GetComponent<ResourceBuilding>();

		Text.text = $"Уровень 1 -> 2\n";
		Text.text += $"Количество получаемых ресурсов 1 -> 2\n";
		Text.text += $"Количество ресурсов для кормления 1 -> 2\n";

		WaterBuilding.OnUpgrade += UpdateData;
	}

	public void UpdateData()
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

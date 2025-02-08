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

		UpdateData();
		WaterBuilding.OnUpgrade += UpdateData;
	}

	public void UpdateData()
	{
		if (WaterBuilding.CurrentLevel.CurrentLevelNumber == 20)
		{
			Text.text = $"Уровень max: {WaterBuilding.CurrentLevel.CurrentLevelNumber}\n";

			Text.text += $"Время получаемой воды: {WaterBuilding.TimerForGetResourses} сек";
		}
		else
		{
			Text.text = $"Уровень {WaterBuilding.CurrentLevel.CurrentLevelNumber} -> {WaterBuilding.NextLevelData().CurrentLevelNumber}\n";

			Text.text += $"Время получаемой воды: {WaterBuilding.TimerForGetResourses} сек -> {WaterBuilding.TimerForGetResourses-1} сек";
		}
	}
}

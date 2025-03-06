using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food_Quality_Text : MonoBehaviour
{
	private GameObject Building { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private ResourceBuilding FoodBuilding { get; set; }

	public void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();

		Building = GameObject.FindGameObjectWithTag("FoodBuilding");
		FoodBuilding = Building.GetComponent<ResourceBuilding>();

		UpdateData();

		FoodBuilding.OnUpgrade += UpdateData;
	}

	public void UpdateData()
	{
		if (FoodBuilding.CurrentLevel.CurrentLevelNumber == FoodBuilding.GetLevelsCount())
		{
			Text.text = $"Уровень max: {FoodBuilding.CurrentLevel.CurrentLevelNumber}\n";
			Text.text += $"Количество получаемых ресурсов: {FoodBuilding.CurrentLevel.IncomePerSecondValue}\n";
			Text.text += $"Количество ресурсов для кормления: {FoodBuilding.CurrentLevel.DragResourceCapacity}\n";
		}
		else
		{
			Text.text = $"Уровень {FoodBuilding.CurrentLevel.CurrentLevelNumber} -> {FoodBuilding.NextLevelValueData().CurrentLevelNumber}\n";
			Text.text += $"Количество получаемых ресурсов {FoodBuilding.CurrentLevel.IncomePerSecondValue} -> {FoodBuilding.NextLevelValueData().IncomePerSecondValue}\n";
			Text.text += $"Количество ресурсов для кормления {FoodBuilding.CurrentLevel.DragResourceCapacity} -> {FoodBuilding.NextLevelValueData().DragResourceCapacity}\n";
		}
	}
}

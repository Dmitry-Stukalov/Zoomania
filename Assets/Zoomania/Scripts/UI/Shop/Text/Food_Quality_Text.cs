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
		if (FoodBuilding.CurrentLevel.CurrentLevelNumber == 20)
		{
			Text.text = $"Уровень max: {FoodBuilding.CurrentLevel.CurrentLevelNumber}\n";

			Text.text += $"Количество получаемой воды: {FoodBuilding.CurrentLevel.IncomePerClickValue}";
		}
		else
		{
			Text.text = $"Уровень {FoodBuilding.CurrentLevel.CurrentLevelNumber} -> {FoodBuilding.NextLevelData().CurrentLevelNumber}\n";

			Text.text += $"Количество получаемой воды: {FoodBuilding.CurrentLevel.IncomePerClickValue} -> {FoodBuilding.NextLevelData().IncomePerClickValue}";
		}
	}
}

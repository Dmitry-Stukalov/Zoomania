using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food_Speed_Text : MonoBehaviour
{
    private GameObject Building { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private ResourceBuilding FoodBuilding { get; set; }

	public void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();

		Building = GameObject.FindGameObjectWithTag("WaterBuilding");
		FoodBuilding = Building.GetComponent<ResourceBuilding>();

		UpdateData();
		FoodBuilding.OnUpgrade += UpdateData;
	}

	public void UpdateData()
	{
		if (FoodBuilding.CurrentLevel.CurrentLevelNumber == FoodBuilding.GetLevelsCount())
		{
			Text.text = $"Уровень max: {FoodBuilding.CurrentImproveLevel.CurrentLevelNumber}\n";

			Text.text += $"Время получаемой еды: {FoodBuilding.CurrentImproveLevel.EffectValue} сек";
		}
		else
		{
			Text.text = $"Уровень {FoodBuilding.CurrentImproveLevel.CurrentLevelNumber} -> {FoodBuilding.NextLevelTimerData().CurrentLevelNumber}\n";

			Text.text += $"Время получаемой еды: {FoodBuilding.CurrentImproveLevel.EffectValue} сек -> {FoodBuilding.NextLevelTimerData().EffectValue} сек";
		}
	}
}

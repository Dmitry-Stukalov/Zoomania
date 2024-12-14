using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodShopText : MonoBehaviour
{
	private FoodBuilding foodBuilding;
	private TextMeshProUGUI text;

	public void Start()
	{
		foodBuilding = GameObject.FindGameObjectWithTag("FoodBuilding").GetComponent<FoodBuilding>();

		text = gameObject.GetComponent<TextMeshProUGUI>();
		text.text = $"Уровень {foodBuilding.CurrentLevel.CurrentLevelNumber} -> {foodBuilding.CurrentLevel.CurrentLevelNumber + 1}\n";
		text.text += $"Доход за время {foodBuilding.CurrentLevel.IncomePerSecondValue} -> {foodBuilding.CurrentLevel.IncomePerSecondValue + 4}\n";
		text.text += $"Доход за клик {foodBuilding.CurrentLevel.IncomePerClickValue} -> {foodBuilding.CurrentLevel.IncomePerClickValue + 4}\n";

		foodBuilding.OnLevelUp += UpdateData;
	}

	public void UpdateData()
	{
		text.text = $"Уровень {foodBuilding.CurrentLevel.CurrentLevelNumber} -> {foodBuilding.CurrentLevel.CurrentLevelNumber + 1}\n";

		text.text += $"Доход за время {foodBuilding.CurrentLevel.IncomePerSecondValue} -> {foodBuilding.CurrentLevel.IncomePerSecondValue + 5}\n";

		text.text += $"Доход за клик {foodBuilding.CurrentLevel.IncomePerClickValue} -> {foodBuilding.CurrentLevel.IncomePerClickValue + 5}\n";

	}
}

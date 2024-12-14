using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaterShopText : MonoBehaviour
{
	private WaterBuilding waterBuilding;
	private TextMeshProUGUI text;

	public void Start()
	{
		waterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<WaterBuilding>();

		text = gameObject.GetComponent<TextMeshProUGUI>();
		text.text = $"Уровень {waterBuilding.CurrentLevel.CurrentLevelNumber} -> {waterBuilding.CurrentLevel.CurrentLevelNumber + 1}\n";
		text.text += $"Доход за время {waterBuilding.CurrentLevel.IncomePerSecondValue} -> {waterBuilding.CurrentLevel.IncomePerSecondValue + 4}\n";
		text.text += $"Доход за клик {waterBuilding.CurrentLevel.IncomePerClickValue} -> {waterBuilding.CurrentLevel.IncomePerClickValue + 4}\n";

		waterBuilding.OnLevelUp += UpdateData;
	}

	public void UpdateData()
	{
		text.text = $"Уровень {waterBuilding.CurrentLevel.CurrentLevelNumber} -> {waterBuilding.CurrentLevel.CurrentLevelNumber + 1}\n";

		text.text += $"Доход за время {waterBuilding.CurrentLevel.IncomePerSecondValue} -> {waterBuilding.CurrentLevel.IncomePerSecondValue + 5}\n";

		text.text += $"Доход за клик {waterBuilding.CurrentLevel.IncomePerClickValue} -> {waterBuilding.CurrentLevel.IncomePerClickValue + 5}\n";

	}
}

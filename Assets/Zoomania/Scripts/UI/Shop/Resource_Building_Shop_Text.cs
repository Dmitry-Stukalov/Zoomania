using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Resource_Building_Shop_Text : MonoBehaviour
{
	[field: SerializeField] private ResourceBuilding resourceBuilding { get; set; }
	private BuildingLevel LevelData { get; set; }
	private TextMeshProUGUI text {  get; set; }

	public void Start()
	{
		LevelData = resourceBuilding.NextLevelData();

		text = gameObject.GetComponent<TextMeshProUGUI>();
		text.text = $"Уровень {resourceBuilding.CurrentLevel.CurrentLevelNumber} -> {LevelData.CurrentLevelNumber}\n";
		text.text += $"Доход за время {resourceBuilding.CurrentLevel.IncomePerSecondValue} -> {LevelData.IncomePerSecondValue}\n";
		text.text += $"Доход за клик {resourceBuilding.CurrentLevel.IncomePerClickValue} -> {LevelData.IncomePerClickValue}\n";

		resourceBuilding.OnLevelUp += UpdateData;
	}

	public void UpdateData()
	{
		LevelData = resourceBuilding.NextLevelData();

		text.text = $"Уровень {resourceBuilding.CurrentLevel.CurrentLevelNumber} -> {LevelData.CurrentLevelNumber}\n";

		text.text += $"Доход за время {resourceBuilding.CurrentLevel.IncomePerSecondValue} -> {LevelData.IncomePerSecondValue}\n";

		text.text += $"Доход за клик {resourceBuilding.CurrentLevel.IncomePerClickValue} -> {LevelData.IncomePerClickValue}\n";

	}
}

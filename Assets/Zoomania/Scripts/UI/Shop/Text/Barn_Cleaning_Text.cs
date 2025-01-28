using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barn_Cleaning_Text : MonoBehaviour
{
	[field: SerializeField] public GameObject Barn { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private Barn_Cleaning BarnCleaning { get; set; }

	public void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();
		BarnCleaning = Barn.GetComponent<Barn_Cleaning>();

		UpdateData();
		BarnCleaning.OnUpgrade += UpdateData;
	}

	public void UpdateData()
	{
		if (BarnCleaning.NextLevelData() == null)
		{
			Text.text = $"Уровень max: {BarnCleaning.CurrentLevel.CurrentLevelNumber}\n";
		}
		else
		{
			Text.text = $"Уровень {BarnCleaning.CurrentLevel.CurrentLevelNumber} -> {BarnCleaning.NextLevelData().CurrentLevelNumber}\n";

			Text.text += $"Снижение кликов {BarnCleaning.CurrentLevel.EffectValue} -> {BarnCleaning.NextLevelData().EffectValue}\n";
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Deep_Sleep_Text : MonoBehaviour
{
	private GameObject Building { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private Deep_Sleep Sleep { get; set; }

	public void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();

		Building = GameObject.FindGameObjectWithTag("EssenceClick");
		Sleep = Building.GetComponent<Deep_Sleep>();

		UpdateData();

		Sleep.OnUpgrade += UpdateData;
	}

	public void UpdateData()
	{
		if (Sleep.CurrentLevel.CurrentLevelNumber == Sleep.GetLevelsCount() - 1)
		{
			Text.text = $"”ровень max: {Sleep.CurrentLevel.CurrentLevelNumber}\n";
			Text.text += $"Ёффективность кликов: +{Sleep.CurrentLevel.EffectValue}\n";
		}
		else
		{
			Text.text = $"”ровень {Sleep.CurrentLevel.CurrentLevelNumber} -> {Sleep.NextLevelData().CurrentLevelNumber}\n";
			Text.text += $"Ёффективность кликов +{Sleep.CurrentLevel.EffectValue} -> +{Sleep.NextLevelData().EffectValue}\n";
		}
	}
}

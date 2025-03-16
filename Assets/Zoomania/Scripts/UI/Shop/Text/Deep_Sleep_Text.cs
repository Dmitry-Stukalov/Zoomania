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
		if (Sleep.CurrentLevelData().CurrentLevelNumber == Sleep.GetLevelsCount() - 1)
		{
			Text.text = $"”ровень max: {Sleep.CurrentLevelData().CurrentLevelNumber}\n";
			Text.text += $"Ёффективность кликов: +{Sleep.CurrentLevelData().EffectValue}\n";
		}
		else
		{
			Text.text = $"”ровень {Sleep.CurrentLevelData().CurrentLevelNumber} -> {Sleep.NextLevelData().CurrentLevelNumber}\n";
			Text.text += $"Ёффективность кликов +{Sleep.CurrentLevelData().EffectValue} -> +{Sleep.NextLevelData().EffectValue}\n";
		}
	}
}

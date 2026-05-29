using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Flashlights_Text : ShopTextBase
{
	private Buy_Flashlights Flashlights { get; set; }

	protected override void Start()
	{
		base.Start();

		Flashlights = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Flashlights>();

		Flashlights.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		LevelNumber.text = Flashlights.CurrentLevelData().CurrentLevelNumber.ToString();

		Text.text = $"Коэффициент пассивного дохода: *{Flashlights.CurrentLevelData().EffectValue}\n";
	}
}

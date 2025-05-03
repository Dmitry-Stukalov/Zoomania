using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bamboo_Text : ShopTextBase
{
	private Buy_Bamboo Bamboo { get; set; }

	protected override void Start()
	{
		base.Start();

		Bamboo = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Bamboo>();

		Bamboo.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		LevelNumber.text = Bamboo.CurrentLevelData().CurrentLevelNumber.ToString();

		Text.text = $"Клики: +{Bamboo.CurrentLevelData().EffectValue}\n";
	}
}

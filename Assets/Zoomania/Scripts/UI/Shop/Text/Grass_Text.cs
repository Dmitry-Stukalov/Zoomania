using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Grass_Text : ShopTextBase
{
	private Buy_Grass Grass { get; set; }

	protected override void Start()
	{
		base.Start();

		Grass = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Grass>();

		Grass.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		LevelNumber.text = Grass.CurrentLevelData().CurrentLevelNumber.ToString();

		Text.text = $"Клики: +{Grass.CurrentLevelData().EffectValue}\n";
	}
}

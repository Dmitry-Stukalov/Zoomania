using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pond_Text : ShopTextBase
{
	private Buy_Pond Pond { get; set; }

	protected override void Start()
	{
		base.Start();

		Pond = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Pond>();

		Pond.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		LevelNumber.text = Pond.CurrentLevelData().CurrentLevelNumber.ToString();

		Text.text = $"Клики: +{Pond.CurrentLevelData().EffectValue}\n";
	}
}

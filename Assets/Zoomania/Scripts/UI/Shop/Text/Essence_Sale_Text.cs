using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Essence_Sale_Text : ShopTextBase
{
	private Essence_Storage Storage { get; set; }
	private Essence_Quality Quality { get; set; }

	protected override void Start()
	{
		base.Start();

		Storage = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Storage>();
		Storage.OnChange += UpdateData;

		Quality = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Quality>();
		Quality.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		Text.text = $"+ {Storage.GetEssenceCount() * Quality.CurrentLevelData().EffectValue}";
	}
}

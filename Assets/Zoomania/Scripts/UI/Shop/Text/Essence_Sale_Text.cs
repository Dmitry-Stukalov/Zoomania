using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Essence_Sale_Text : ShopTextBase
{
	private Essence_Storage Storage { get; set; }

	protected override void Start()
	{
		base.Start();

		Storage = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Storage>();
		Storage.OnChange += UpdateData;

		Text.text = $"Количество эссенций: 0";
	}

	protected override void UpdateData()
	{
		Text.text = $"Количество эссенций: {Storage.GetEssenceCount()}";
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Essence_Sale_Button : ShopUpgradeButtonBase
{
	private Essence_Quality EssenceQuality { get; set; }
	private Essence_Storage storage { get; set; }


	protected override void Start()
	{
		base.Start();

		storage = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Storage>();
		storage.OnChange += UpdateData;

		EssenceQuality = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Quality>();

		Text.text = TextConversion(0);
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		Money.IncomeMoney.Resource += storage.GetEssenceCount() * EssenceQuality.CurrentLevelData().EffectValue;
		Money.InvokeChanges();
		storage.SoldOut();

		UpdateData();
	}

	protected override void UpdateData()
	{
		Text.text = TextConversion(storage.GetEssenceCount() * EssenceQuality.CurrentLevelData().EffectValue);
	}

}

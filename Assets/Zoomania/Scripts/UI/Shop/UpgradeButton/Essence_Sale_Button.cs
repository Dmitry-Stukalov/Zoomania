using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Essence_Sale_Button : ShopUpgradeButtonBase
{
	/*private Essence_Quality EssenceQuality { get; set; }
	private Essence_Storage Storage { get; set; }


	protected override void Start()
	{
		base.Start();

		EssenceQuality = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Quality>();

		Storage = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Storage>();
		Storage.OnChange += UpdateData;
		UpdateData();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		Money.IncomeMoney.Resource += Storage.GetEssenceCount() * EssenceQuality.CurrentLevelData().EffectValue;
		Money.InvokeChanges();
		Storage.SoldOut();

		UpdateData();
	}

	protected override void UpdateData()
	{
		CheckMask();
	}

	protected override void CheckMask()
	{
		base.CheckMask();

		if (Storage.GetEssenceCount() == 0) Mask.SetActive(true);
		else Mask.SetActive(false);
	}*/
}

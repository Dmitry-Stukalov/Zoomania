using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buy_Panda_Button : ShopUpgradeButtonBase
{
	private Barn barn { get; set; }

	protected override void Start()
	{
		base.Start();

		barn = GameObject.FindGameObjectWithTag("Barn").GetComponent<Barn>();

		barn.Spawn += UpdateData;
		UpdateData();
		CheckMask();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < barn.MoneyToSpawn)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(barn.MoneyToSpawn);

		barn.SpawnAnimal();

		UpdateData();
	}

	protected override void UpdateData()
	{
		Text.text = TextConversion(barn.MoneyToSpawn);
	}

	protected override void CheckMask()
	{
		base.CheckMask();

		if (Money.IncomeMoney.Resource < barn.MoneyToSpawn && !Mask.activeSelf)
		{
			Mask.SetActive(true);
			IsEnough = false;
		}
		if (Money.IncomeMoney.Resource >= barn.MoneyToSpawn && Mask.activeSelf)
		{
			Mask.SetActive(false);
			IsEnough = true;
		}
	}
}

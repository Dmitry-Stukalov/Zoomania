using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Flashlights_Button : ShopUpgradeButtonBase
{
	private Buy_Flashlights Flashlights;

	protected override void Start()
	{
		base.Start();

		Flashlights = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Flashlights>();

		UpdateData();
		CheckMask();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < Flashlights.CurrentLevelData().MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(Flashlights.CurrentLevelData().MoneyForUpgrade);

		Flashlights.Upgrade();

		UpdateData();

		CheckMask();
	}

	protected override void UpdateData()
	{
		if (Flashlights.CurrentLevelData().CurrentLevelNumber == Flashlights.GetLevelsCount() - 1) gameObject.SetActive(false);
		Text.text = TextConversion(Flashlights.CurrentLevelData().MoneyForUpgrade);
	}

	protected override void CheckMask()
	{
		base.CheckMask();

		if (Money.IncomeMoney.Resource < Flashlights.CurrentLevelData().MoneyForUpgrade && !Mask.activeSelf)
		{
			Mask.SetActive(true);
			IsEnough = false;
		}
		if (Money.IncomeMoney.Resource >= Flashlights.CurrentLevelData().MoneyForUpgrade && Mask.activeSelf)
		{
			Mask.SetActive(false);
			IsEnough = true;
		}
	}
}

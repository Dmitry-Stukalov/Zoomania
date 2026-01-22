using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Couch_Button : ShopUpgradeButtonBase
{
	private Buy_Couch Couch;

	protected override void Start()
	{
		base.Start();

		Couch = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Couch>();

		UpdateData();
		CheckMask();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < Couch.CurrentLevelData().MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(Couch.CurrentLevelData().MoneyForUpgrade);

		Couch.Upgrade();

		UpdateData();

		CheckMask();
	}

	protected override void UpdateData()
	{
		if (Couch.CurrentLevelData().CurrentLevelNumber == Couch.GetLevelsCount() - 1) gameObject.SetActive(false);
		Text.text = TextConversion(Couch.CurrentLevelData().MoneyForUpgrade);
	}

	protected override void CheckMask()
	{
		base.CheckMask();

		if (Money.IncomeMoney.Resource < Couch.CurrentLevelData().MoneyForUpgrade && !Mask.activeSelf)
		{
			Mask.SetActive(true);
			IsEnough = false;
		}
		if (Money.IncomeMoney.Resource >= Couch.CurrentLevelData().MoneyForUpgrade && Mask.activeSelf)
		{
			Mask.SetActive(false);
			IsEnough = true;
		}
	}
}

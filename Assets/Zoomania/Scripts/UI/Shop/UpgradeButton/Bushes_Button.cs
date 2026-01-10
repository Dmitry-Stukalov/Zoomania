using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bushes_Button : ShopUpgradeButtonBase
{
	private Buy_Bushes Bushes;

	protected override void Start()
	{
		base.Start();

		Bushes = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Bushes>();

		UpdateData();
		CheckMask();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < Bushes.CurrentLevelData().MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(Bushes.CurrentLevelData().MoneyForUpgrade);

		Bushes.Upgrade();

		UpdateData();

		CheckMask();
	}

	protected override void UpdateData()
	{
		if (Bushes.CurrentLevelData().CurrentLevelNumber == Bushes.GetLevelsCount() - 1) gameObject.SetActive(false);
		Text.text = TextConversion(Bushes.CurrentLevelData().MoneyForUpgrade);
	}

	protected override void CheckMask()
	{
		base.CheckMask();

		if (Money.IncomeMoney.Resource < Bushes.CurrentLevelData().MoneyForUpgrade && !Mask.activeSelf)
		{
			Mask.SetActive(true);
			IsEnough = false;
		}
		if (Money.IncomeMoney.Resource >= Bushes.CurrentLevelData().MoneyForUpgrade && Mask.activeSelf)
		{
			Mask.SetActive(false);
			IsEnough = true;
		}
	}
}

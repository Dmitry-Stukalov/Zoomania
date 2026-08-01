using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bamboo_Button : ShopUpgradeButtonBase
{
	/*private Buy_Bamboo Bamboo { get; set; }

	protected override void Start()
	{
		base.Start();

		Bamboo = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Bamboo>();

		UpdateData();
		CheckMask();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < Bamboo.CurrentLevelData().MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(Bamboo.CurrentLevelData().MoneyForUpgrade);

		Bamboo.Upgrade();

		UpdateData();

		CheckMask();
	}

	protected override void UpdateData()
	{
		if (Bamboo.CurrentLevelData().CurrentLevelNumber == Bamboo.GetLevelsCount() - 1) gameObject.SetActive(false);
		Text.text = TextConversion(Bamboo.CurrentLevelData().MoneyForUpgrade);
	}

	protected override void CheckMask()
	{
		base.CheckMask();

		if (Money.IncomeMoney.Resource < Bamboo.CurrentLevelData().MoneyForUpgrade && !Mask.activeSelf)
		{
			Mask.SetActive(true);
			IsEnough = false;
		}
		if (Money.IncomeMoney.Resource >= Bamboo.CurrentLevelData().MoneyForUpgrade && Mask.activeSelf)
		{
			Mask.SetActive(false);
			IsEnough = true;
		}
	}*/
}

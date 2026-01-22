using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pond_Button : ShopUpgradeButtonBase
{
	private Buy_Pond Pond;

	protected override void Start()
	{
		base.Start();

		Pond = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Pond>();

		UpdateData();
		CheckMask();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < Pond.CurrentLevelData().MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(Pond.CurrentLevelData().MoneyForUpgrade);

		Pond.Upgrade();

		UpdateData();

		CheckMask();
	}

	protected override void UpdateData()
	{
		if (Pond.CurrentLevelData().CurrentLevelNumber == Pond.GetLevelsCount() - 1) gameObject.SetActive(false);
		Text.text = TextConversion(Pond.CurrentLevelData().MoneyForUpgrade);
	}

	protected override void CheckMask()
	{
		base.CheckMask();

		if (Money.IncomeMoney.Resource < Pond.CurrentLevelData().MoneyForUpgrade && !Mask.activeSelf)
		{
			Mask.SetActive(true);
			IsEnough = false;
		}
		if (Money.IncomeMoney.Resource >= Pond.CurrentLevelData().MoneyForUpgrade && Mask.activeSelf)
		{
			Mask.SetActive(false);
			IsEnough = true;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slide_Button : ShopUpgradeButtonBase
{
	/*private Buy_Slide Slide;

	protected override void Start()
	{
		base.Start();

		Slide = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Slide>();

		UpdateData();
		CheckMask();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < Slide.CurrentLevelData().MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(Slide.CurrentLevelData().MoneyForUpgrade);

		Slide.Upgrade();

		UpdateData();

		CheckMask();
	}

	protected override void UpdateData()
	{
		if (Slide.CurrentLevelData().CurrentLevelNumber == Slide.GetLevelsCount() - 1) gameObject.SetActive(false);
		Text.text = TextConversion(Slide.CurrentLevelData().MoneyForUpgrade);
	}

	protected override void CheckMask()
	{
		base.CheckMask();

		if (Money.IncomeMoney.Resource < Slide.CurrentLevelData().MoneyForUpgrade && !Mask.activeSelf)
		{
			Mask.SetActive(true);
			IsEnough = false;
		}
		if (Money.IncomeMoney.Resource >= Slide.CurrentLevelData().MoneyForUpgrade && Mask.activeSelf)
		{
			Mask.SetActive(false);
			IsEnough = true;
		
	}*/
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Essence_Quality_Button : ShopUpgradeButtonBase
{
	private Essence_Quality EssenceQuality { get; set; }


	protected override void Start()
	{
		base.Start();

		EssenceQuality = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Quality>();

		UpdateData();

		CheckMask();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < EssenceQuality.CurrentLevelData().MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(EssenceQuality.CurrentLevelData().MoneyForUpgrade);

		EssenceQuality.Upgrade();

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (EssenceQuality.CurrentLevelData().CurrentLevelNumber == EssenceQuality.GetLevelsCount()) gameObject.SetActive(false);
		Text.text = TextConversion(EssenceQuality.CurrentLevelData().MoneyForUpgrade);
	}

	protected override void CheckMask()
	{
		base.CheckMask();

		if (Money.IncomeMoney.Resource < EssenceQuality.CurrentLevelData().MoneyForUpgrade && !Mask.activeSelf)
		{
			Mask.SetActive(true);
			IsEnough = false;
		}
		if (Money.IncomeMoney.Resource >= EssenceQuality.CurrentLevelData().MoneyForUpgrade && Mask.activeSelf)
		{
			Mask.SetActive(false);
			IsEnough = true;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Grass_Button : ShopUpgradeButtonBase
{
	/*private Buy_Grass Grass;

	protected override void Start()
	{
		base.Start();

		Grass = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Grass>();

		UpdateData();
		CheckMask();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < Grass.CurrentLevelData().MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(Grass.CurrentLevelData().MoneyForUpgrade);

		Grass.Upgrade();

		UpdateData();

		CheckMask();
	}

	protected override void UpdateData()
	{
		if (Grass.CurrentLevelData().CurrentLevelNumber == Grass.GetLevelsCount() - 1) gameObject.SetActive(false);
		Text.text = TextConversion(Grass.CurrentLevelData().MoneyForUpgrade);
	}

	protected override void CheckMask()
	{
		base.CheckMask();

		if (Money.IncomeMoney.Resource < Grass.CurrentLevelData().MoneyForUpgrade && !Mask.activeSelf)
		{
			Mask.SetActive(true);
			IsEnough = false;
		}
		if (Money.IncomeMoney.Resource >= Grass.CurrentLevelData().MoneyForUpgrade && Mask.activeSelf)
		{
			Mask.SetActive(false);
			IsEnough = true;
		}
	}*/
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food_Speed_Button : ShopUpgradeButtonBase
{
	private FoodBuildingTimer FoodBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		FoodBuilding = GameObject.FindGameObjectWithTag("NewFood").GetComponent<FoodBuildingTimer>();

		UpdateData();

		CheckMask();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{ 
		if (Money.IncomeMoney.Resource < FoodBuilding.CurrentLevelData().MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(FoodBuilding.CurrentLevelData().MoneyForUpgrade);

		FoodBuilding.Upgrade();

		UpdateData();

		CheckMask();
	}

	protected override void UpdateData()
	{
		if (FoodBuilding.CurrentLevelData().CurrentLevelNumber == FoodBuilding.GetLevelsCount()) gameObject.SetActive(false);
		Text.text = TextConversion(FoodBuilding.CurrentLevelData().MoneyForUpgrade);
	}

	protected override void CheckMask()
	{
		base.CheckMask();

		if (Money.IncomeMoney.Resource < FoodBuilding.CurrentLevelData().MoneyForUpgrade && !Mask.activeSelf)
		{
			Mask.SetActive(true);
			IsEnough = false;
		}
		if (Money.IncomeMoney.Resource >= FoodBuilding.CurrentLevelData().MoneyForUpgrade && Mask.activeSelf)
		{
			Mask.SetActive(false);
			IsEnough = true;
		}
	}
}

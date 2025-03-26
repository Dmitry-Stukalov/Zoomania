using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food_Quality_Button : ShopUpgradeButtonBase
{
	private FoodBuildingValue FoodBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		FoodBuilding = GameObject.FindGameObjectWithTag("NewFood").GetComponent<FoodBuildingValue>();

		UpdateData();
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
	}

	protected override void UpdateData()
	{
		if (FoodBuilding.CurrentLevelData().CurrentLevelNumber == FoodBuilding.GetLevelsCount()) gameObject.SetActive(false);
		Text.text = TextConversion(FoodBuilding.CurrentLevelData().MoneyForUpgrade);
	}
}

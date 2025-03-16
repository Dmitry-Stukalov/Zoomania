using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food_Quality_Button : ShopUpgradeButtonBase
{
	private ResourceBuilding FoodBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		FoodBuilding = GameObject.FindGameObjectWithTag("FoodBuilding").GetComponent<ResourceBuilding>();

		UpdateData();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < FoodBuilding.CurrentLevel.MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(FoodBuilding.CurrentLevel.MoneyForUpgrade);

		FoodBuilding.UpgradeValue();

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (FoodBuilding.CurrentLevel.CurrentLevelNumber == FoodBuilding.GetLevelsCount()) gameObject.SetActive(false);
		Text.text = TextConversion(FoodBuilding.CurrentLevel.MoneyForUpgrade);
	}
}

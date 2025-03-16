using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food_Speed_Button : ShopUpgradeButtonBase
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
		if (Money.IncomeMoney.Resource < FoodBuilding.CurrentImproveLevel.MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(FoodBuilding.CurrentImproveLevel.MoneyForUpgrade);

		FoodBuilding.UpgradeTimer();

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (FoodBuilding.CurrentLevel.CurrentLevelNumber == FoodBuilding.GetImprovementLevelsCount()) gameObject.SetActive(false);
		Text.text = TextConversion(FoodBuilding.CurrentImproveLevel.MoneyForUpgrade);
	}
}

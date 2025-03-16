using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buy_Food_Button : ShopUpgradeButtonBase
{
	private ResourceBuilding FoodBuilding { get; set; }
	private int AddCapacity { get; set; } = 10;


	protected override void Start()
	{
		base.Start();

		FoodBuilding = GameObject.FindGameObjectWithTag("FoodBuilding").GetComponent<ResourceBuilding>();

		Text.text = TextConversion(5);
	}

	public override void OnPointerClick(PointerEventData eventData)
	{

		if (Money.IncomeMoney.Resource < 5)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(5);

		FoodBuilding.AddData(10);
	}
}

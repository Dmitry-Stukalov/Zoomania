using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buy_Water_Button : ShopUpgradeButtonBase
{
	private ResourceBuilding WaterBuilding { get; set; }
	private int AddCapacity { get; set; } = 10;


	protected override void Start()
	{
		base.Start();

		WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<ResourceBuilding>();

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

		WaterBuilding.AddData(10);
	}
}

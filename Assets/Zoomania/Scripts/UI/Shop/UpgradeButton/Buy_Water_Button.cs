using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buy_Water_Button : ShopUpgradeButtonBase
{
	private WaterBuildingTimer WaterBuilding { get; set; }
	private int NeedMoney { get; set; } = 5;
	private int AddCapacity { get; set; } = 10;


	protected override void Start()
	{
		base.Start();

		WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<WaterBuildingTimer>();

		Text.text = TextConversion(5);

		CheckMask();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{

		if (Money.IncomeMoney.Resource < NeedMoney)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(NeedMoney);

		WaterBuilding.AddResources(AddCapacity);

		CheckMask();
	}

	protected override void CheckMask()
	{
		base.CheckMask();

		if (Money.IncomeMoney.Resource < NeedMoney && !Mask.activeSelf)
		{
			Mask.SetActive(true);
			IsEnough = false;
		}
		if (Money.IncomeMoney.Resource >= NeedMoney && Mask.activeSelf)
		{
			Mask.SetActive(false);
			IsEnough = true;
		}
	}
}

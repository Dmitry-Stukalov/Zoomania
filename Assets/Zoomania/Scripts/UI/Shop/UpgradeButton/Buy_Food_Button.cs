using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buy_Food_Button : ShopUpgradeButtonBase
{
	private FoodBuildingTimer FoodBuilding { get; set; }
	private int NeedMoney { get; set; } = 5;
	private int AddCapacity { get; set; } = 10;


	protected override void Start()
	{
		base.Start();

		FoodBuilding = GameObject.FindGameObjectWithTag("NewFood").GetComponent<FoodBuildingTimer>();

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

		FoodBuilding.AddResources(AddCapacity);

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

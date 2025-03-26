using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Water_Quality_Button : ShopUpgradeButtonBase
{
	private WaterBuildingValue WaterBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<WaterBuildingValue>();

		UpdateData();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < WaterBuilding.CurrentLevel.MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(WaterBuilding.CurrentLevel.MoneyForUpgrade);

		WaterBuilding.Upgrade();

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (WaterBuilding.CurrentLevel.CurrentLevelNumber == WaterBuilding.GetLevelsCount()) gameObject.SetActive(false);
		Text.text = TextConversion(WaterBuilding.CurrentLevel.MoneyForUpgrade);
	}
}

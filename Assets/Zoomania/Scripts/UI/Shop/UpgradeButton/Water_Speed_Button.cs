using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Water_Speed_Button : ShopUpgradeButtonBase
{
	private WaterBuildingTimer WaterBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<WaterBuildingTimer>();

		UpdateData();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < WaterBuilding.CurrentLevelData().EffectValue)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(WaterBuilding.CurrentLevelData().EffectValue);

		WaterBuilding.Upgrade();

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (WaterBuilding.CurrentLevelData().CurrentLevelNumber == WaterBuilding.GetLevelsCount()) gameObject.SetActive(false);
		Text.text = TextConversion(WaterBuilding.CurrentLevelData().MoneyForUpgrade);
	}
}

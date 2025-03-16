using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Water_Speed_Button : ShopUpgradeButtonBase
{
	private ResourceBuilding WaterBuilding { get; set; }

	protected override void Start()
	{
		base.Start();

		WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<ResourceBuilding>();

		UpdateData();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < WaterBuilding.CurrentImproveLevel.EffectValue)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(WaterBuilding.CurrentImproveLevel.EffectValue);

		WaterBuilding.UpgradeTimer();

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (WaterBuilding.CurrentImproveLevel.CurrentLevelNumber == WaterBuilding.GetImprovementLevelsCount()) gameObject.SetActive(false);
		Text.text = TextConversion(WaterBuilding.CurrentImproveLevel.MoneyForUpgrade);
	}
}

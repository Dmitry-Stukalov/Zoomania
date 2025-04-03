using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deep_Sleep_Button : ShopUpgradeButtonBase
{
	[field: SerializeField] private Deep_Sleep Sleep { get; set; }

	protected override void Start()
	{
		base.Start();

		UpdateData();
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (Money.IncomeMoney.Resource < Sleep.CurrentLevelData().MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		Money.SetMoneyValue(Sleep.CurrentLevelData().MoneyForUpgrade);

		Sleep.Upgrade();

		UpdateData();
	}

	protected override void UpdateData()
	{
		if (Sleep.CurrentLevelData().CurrentLevelNumber == Sleep.GetLevelsCount() - 1) gameObject.SetActive(false);
		Text.text = TextConversion(Sleep.CurrentLevelData().MoneyForUpgrade);
	}
}

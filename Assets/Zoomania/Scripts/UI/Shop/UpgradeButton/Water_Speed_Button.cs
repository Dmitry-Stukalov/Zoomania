using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Water_Speed_Button : MonoBehaviour, IPointerClickHandler
{
	private GameObject Buiding { get; set; }
	private Money moneyperclick { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private ResourceBuilding WaterBuilding { get; set; }

	public void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<Money>();

		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

		Buiding = GameObject.FindGameObjectWithTag("WaterBuilding");

		WaterBuilding = Buiding.GetComponent<ResourceBuilding>();

		//UpdateData();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (moneyperclick.IncomeMoney.Resource < WaterBuilding.CurrentImproveLevel.EffectValue)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		moneyperclick.SetMoneyValue(WaterBuilding.CurrentImproveLevel.EffectValue);

		WaterBuilding.UpgradeTimer();

		UpdateData();
	}

	public void UpdateData()
	{
		if (WaterBuilding.CurrentImproveLevel.CurrentLevelNumber == WaterBuilding.GetImprovementLevelsCount()) gameObject.SetActive(false);
		Text.text = TextConversion(WaterBuilding.CurrentImproveLevel.MoneyForUpgrade);
	}

	public string TextConversion(float value)
	{
		string text;
		if (value < 1000) return value.ToString();
		if (value >= 1000 && value < 1000000)
		{
			value /= 1000;
			value = Mathf.Floor(value * 10) / 10;
			text = value.ToString() + "k";
			return text;
		}
		if (value >= 10000000)
		{
			value /= 1000000;
			value = Mathf.Floor(value * 10) / 10;
			text = value.ToString() + "M";
			return text;
		}

		return null;
	}
}

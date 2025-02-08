using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buy_Water_Button : MonoBehaviour, IPointerClickHandler
{
	private ResourceBuilding WaterBuilding { get; set; }
	private Money moneyperclick { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private int AddCapacity { get; set; }


	public void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<Money>();

		WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<ResourceBuilding>();

		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
		Text.text = TextConversion(5);

		AddCapacity = 10;
	}

	public void OnPointerClick(PointerEventData eventData)
	{

		if (moneyperclick.IncomeMoney.Resource < 5)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		moneyperclick.SetMoneyValue(5);

		WaterBuilding.AddData(10);
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

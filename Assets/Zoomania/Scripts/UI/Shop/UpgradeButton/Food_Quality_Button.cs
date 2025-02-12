using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Food_Quality_Button : MonoBehaviour, IPointerClickHandler
{
	private GameObject Buiding { get; set; }
	private Money moneyperclick { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private ResourceBuilding FoodBuilding { get; set; }

	public void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<Money>();

		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

		Buiding = GameObject.FindGameObjectWithTag("FoodBuilding");

		FoodBuilding = Buiding.GetComponent<ResourceBuilding>();

		UpdateData();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (moneyperclick.IncomeMoney.Resource < FoodBuilding.CurrentLevel.MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		moneyperclick.SetMoneyValue(FoodBuilding.CurrentLevel.MoneyForUpgrade);

		FoodBuilding.UpgradeValue();

		UpdateData();
	}

	public void UpdateData()
	{
		if (FoodBuilding.CurrentLevel.CurrentLevelNumber == FoodBuilding.GetLevelsCount()) gameObject.SetActive(false);
		Text.text = TextConversion(FoodBuilding.CurrentLevel.MoneyForUpgrade);
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

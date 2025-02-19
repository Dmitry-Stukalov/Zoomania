using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bamboo_Button : MonoBehaviour, IPointerClickHandler
{
	private GameObject Buiding { get; set; }
	private Money moneyperclick { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private Buy_Bamboo Bamboo { get; set; }

	public void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<Money>();

		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

		Buiding = GameObject.FindGameObjectWithTag("Background");

		Bamboo = Buiding.GetComponent<Buy_Bamboo>();

		Text.text = TextConversion(10);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (moneyperclick.IncomeMoney.Resource < Bamboo.CurrentLevel.MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		moneyperclick.SetMoneyValue(Bamboo.CurrentLevel.MoneyForUpgrade);

		Bamboo.Upgrade();

		UpdateData();
	}

	public void UpdateData()
	{
		if (Bamboo.CurrentLevel.CurrentLevelNumber == Bamboo.GetLevelsCount() - 1) gameObject.SetActive(false);
		Text.text = TextConversion(Bamboo.CurrentLevel.MoneyForUpgrade);
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

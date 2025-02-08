using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buy_Panda_Button : MonoBehaviour, IPointerClickHandler
{
	private Money moneyperclick { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private Barn barn { get; set; }

	public void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<Money>();

		barn = GameObject.FindGameObjectWithTag("Barn").GetComponent<Barn>();

		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();


		UpdateData();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (moneyperclick.IncomeMoney.Resource < barn.MoneyToSpawn)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		moneyperclick.SetMoneyValue(barn.MoneyToSpawn);

		barn.SpawnAnimal();

		UpdateData();
	}

	public void UpdateData()
	{
		Text.text = TextConversion(barn.MoneyToSpawn);
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

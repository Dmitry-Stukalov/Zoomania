using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Essence_Sale_Button : MonoBehaviour, IPointerClickHandler
{
	private Essence_Quality EssenceQuality { get; set; }
	private Money moneyperclick { get; set; }
	private Essence_Storage storage { get; set; }
	private TextMeshProUGUI Text { get; set; }


	public void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<Money>();
		storage = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Storage>();
		storage.OnChange += UpdateData;

		EssenceQuality = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Quality>();

		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

		Text.text = TextConversion(0);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		moneyperclick.IncomeMoney.Resource += storage.GetEssenceCount() * EssenceQuality.CurrentLevel.EffectValue;
		moneyperclick.InvokeChanges();
		storage.SoldOut();

		UpdateData();
	}

	public void UpdateData()
	{
		Text.text = TextConversion(storage.GetEssenceCount() * EssenceQuality.CurrentLevel.EffectValue);
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

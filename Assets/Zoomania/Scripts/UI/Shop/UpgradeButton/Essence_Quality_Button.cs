using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Essence_Quality_Button : MonoBehaviour, IPointerClickHandler
{
	private Money moneyperclick { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private Essence_Quality EssenceQuality { get; set; }


	public void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<Money>();

		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

		EssenceQuality = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Quality>();

		UpdateData();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (moneyperclick.IncomeMoney.Resource < EssenceQuality.CurrentLevelData().MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		moneyperclick.SetMoneyValue(EssenceQuality.CurrentLevelData().MoneyForUpgrade);

		EssenceQuality.Upgrade();

		UpdateData();
	}

	public void UpdateData()
	{
		if (EssenceQuality.CurrentLevelData().CurrentLevelNumber == EssenceQuality.GetLevelsCount()) gameObject.SetActive(false);
		Text.text = TextConversion(EssenceQuality.CurrentLevelData().MoneyForUpgrade);
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

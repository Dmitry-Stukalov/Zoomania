using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Deep_Sleep_Button : MonoBehaviour, IPointerClickHandler
{
	private GameObject Buiding { get; set; }
	private Money moneyperclick { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private Deep_Sleep Sleep { get; set; }

	public void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<Money>();

		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

		Buiding = GameObject.FindGameObjectWithTag("EssenceClick");

		Sleep = Buiding.GetComponent<Deep_Sleep>();

		Text.text = TextConversion(10);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (moneyperclick.IncomeMoney.Resource < Sleep.CurrentLevel.MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		moneyperclick.SetMoneyValue(Sleep.CurrentLevel.MoneyForUpgrade);

		Sleep.Upgrade();

		UpdateData();
	}

	public void UpdateData()
	{
		if (Sleep.CurrentLevel.CurrentLevelNumber == Sleep.GetLevelsCount() - 1) gameObject.SetActive(false);
		Text.text = TextConversion(Sleep.CurrentLevel.MoneyForUpgrade);
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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Essence_Sale_Button : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] public GameObject Buiding { get; set; }
	private MoneyPerClick moneyperclick { get; set; }
	private Essence_Storage storage { get; set; }
	private TextMeshProUGUI Text { get; set; }


	public void Start()
	{
		moneyperclick = Buiding.GetComponent<MoneyPerClick>();
		storage = Buiding.GetComponent<Essence_Storage>();
		storage.OnChange += UpdateData;

		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

		UpdateData();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		moneyperclick.IncomeMoney.Resource += storage.GetEssenceCount() * 5;
		moneyperclick.IncomePerClick();
		storage.SoldOut();

		UpdateData();
	}

	public void UpdateData()
	{
		Text.text = TextConversion(storage.GetEssenceCount()*5);
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

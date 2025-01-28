using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Barn_Cleaning_Button : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] public GameObject Buiding { get; set; }
	private MoneyPerClick moneyperclick { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private Barn_Cleaning BarnCleaning { get; set; }


	public void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();

		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

		BarnCleaning = Buiding.GetComponent<Barn_Cleaning>();

		UpdateData();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (moneyperclick.IncomeMoney.Resource < BarnCleaning.CurrentLevel.MoneyForUpgrade)
		{
			Debug.Log("Недостаточно монет");
			return;
		}

		moneyperclick.SetMoneyValue(BarnCleaning.CurrentLevel.MoneyForUpgrade);

		BarnCleaning.Upgrade();

		UpdateData();
	}

	public void UpdateData()
	{
		if (BarnCleaning.CurrentLevel.CurrentLevelNumber == 5) this.gameObject.SetActive(false);
		Text.text = TextConversion(BarnCleaning.CurrentLevel.MoneyForUpgrade);
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

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static Unity.Collections.AllocatorManager;

public class Upgrade_Button : MonoBehaviour, IPointerClickHandler
{ 
	[field: SerializeField] public GameObject Buiding { get; set; } 
	private MoneyPerClick moneyperclick { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private MonoBehaviour Script { get; set; }

	private ResourceBuilding resourceBuiding { get; set; }
	private Barn Barn{ get; set; }
	private HeadOfBarn Head {  get; set; }
	private bool IsResourceBuilding { get; set; } = false;
	private bool IsBarn { get; set; } = false;
	private bool IsHead { get; set; } = false;
	private bool IsSleeping { get; set; } = true;

	void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();

		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

		Script = GetScript<ResourceBuilding, Barn, HeadOfBarn>(Buiding);

		if (IsResourceBuilding) resourceBuiding = Script.GetComponent<ResourceBuilding>();
		if (IsBarn) Barn = Script.GetComponent<Barn>();
		if (IsHead) Head = Script.GetComponent<HeadOfBarn>();

		UpdateData();
	}

	public MonoBehaviour GetScript<T1, T2, T3>(GameObject Building) where T1: ResourceBuilding where T2: Barn where T3: HeadOfBarn
	{
		if (Buiding.TryGetComponent<T1>(out T1 script1))
		{
			IsResourceBuilding = true;
			return script1;
		}
		else if (Buiding.TryGetComponent<T2>(out T2 script2))
		{
			IsBarn = true;
			return script2;
		}
		else if (Buiding.TryGetComponent<T3>(out T3 script3))
		{
			IsHead = true;
			return script3;
		}

		return null;
	}

	public void OnPointerClick(PointerEventData data)
	{
		if (IsResourceBuilding)
		{
			if (moneyperclick.IncomeMoney.Resource < resourceBuiding.CurrentLevel.MoneyForUpgrade)
			{
				Debug.Log("Недостаточно монет");
				return;
			}

			moneyperclick.SetMoneyValue(resourceBuiding.CurrentLevel.MoneyForUpgrade);

			resourceBuiding.LevelUp();

			UpdateData();
		}

		if (IsBarn)
		{
			if (moneyperclick.IncomeMoney.Resource < Barn.CurrentLevel.MoneyForUpgrade)
			{
				Debug.Log("Недостаточно монет");
				return;
			}

			moneyperclick.SetMoneyValue(Barn.CurrentLevel.MoneyForUpgrade);

			Barn.Upgrade();

			UpdateData();
		}

		if (IsHead)
		{
			if (moneyperclick.IncomeMoney.Resource < Head.CurrentLevel.MoneyForUpgrade)
			{
				Debug.Log("Недостаточно монет");
				return;
			}

			if (IsSleeping)
			{
				moneyperclick.SetMoneyValue(Head.CurrentLevel.MoneyForUpgrade);

				Head.gameObject.SetActive(true);
				IsSleeping = false;
				Head.Upgrade();
				UpdateData();
			}
			else
			{
				moneyperclick.SetMoneyValue(Head.CurrentLevel.MoneyForUpgrade);

				Head.Upgrade();

				UpdateData();
			}
		}
	}

	public void UpdateData()
	{
		if (IsResourceBuilding)
		{
			if (resourceBuiding.CurrentLevel.CurrentLevelNumber == 20) this.gameObject.SetActive(false);
			Text.text = TextConversion(resourceBuiding.CurrentLevel.MoneyForUpgrade);
		}

		if (IsBarn)
		{
			if (Barn.CurrentLevel.CurrentLevelNumber == 10) this.gameObject.SetActive(false);
			Text.text = TextConversion(Barn.CurrentLevel.MoneyForUpgrade);
		}

		if (IsHead)
		{
			if (Head.CurrentLevel.CurrentLevelNumber == 10) this.gameObject.SetActive(false);
			Text.text = TextConversion(Head.CurrentLevel.MoneyForUpgrade);
		}
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
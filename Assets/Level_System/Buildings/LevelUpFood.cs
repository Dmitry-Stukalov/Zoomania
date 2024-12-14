using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelUpFood : MonoBehaviour, IPointerClickHandler
{
	private FoodBuilding foodBuilding;

	public MoneyPerClick moneyperclick;

	private TextMeshProUGUI text;

	public void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();

		foodBuilding = GameObject.FindGameObjectWithTag("FoodBuilding").GetComponent<FoodBuilding>();

		text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
		text.text = "";
		text.text += $"{foodBuilding.CurrentLevel.MoneyForUpgrage}";
	}

	public void OnPointerClick(PointerEventData data)
	{
		//moneyperclick.SetMoneyValue(foodBuilding.CurrentLevel.MoneyForUpgrage);
		foodBuilding.LevelUp();
		UpdateData();
	}

	public void UpdateData()
	{
		text.text = $"{foodBuilding.CurrentLevel.MoneyForUpgrage}";
	}
}

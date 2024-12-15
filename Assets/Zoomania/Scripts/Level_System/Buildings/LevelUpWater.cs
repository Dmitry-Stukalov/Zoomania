using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelUpWater : MonoBehaviour, IPointerClickHandler
{
	public Sprite icon { get; private set; }

	private WaterBuilding waterBuilding;

	public MoneyPerClick moneyperclick;

	private TextMeshProUGUI text;

	public void Start()
	{
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();

		waterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<WaterBuilding>();

		text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
		text.text = "";
		text.text += $"{waterBuilding.CurrentLevel.MoneyForUpgrage}";
	}

	public void OnPointerClick(PointerEventData data)
	{
		//moneyperclick.SetMoneyValue(waterBuilding.CurrentLevel.MoneyForUpgrage);
		waterBuilding.LevelUp();
		UpdateData();
	}

	public void UpdateData()
	{
		text.text = $"{waterBuilding.CurrentLevel.MoneyForUpgrage}";
	}
}

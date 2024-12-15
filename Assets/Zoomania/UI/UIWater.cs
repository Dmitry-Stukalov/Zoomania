using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIWater : MonoBehaviour
{
	public GameObject WaterBuilding;
	public TextMeshProUGUI Text;
	public WaterBuilding waterbuildingscript;

	void Start()
	{
		WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding");
		waterbuildingscript = WaterBuilding.GetComponent<WaterBuilding>();
		Text = this.gameObject.GetComponent<TextMeshProUGUI>();
		waterbuildingscript.OnChange += UpdateUI;
	}

	public void UpdateUI()
	{
		Text.text = $"{waterbuildingscript.IncomeWater.Resource.GetValue()}";
	}
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIWater : MonoBehaviour
{
	public GameObject WaterBuilding;
	public TextMeshProUGUI Text;
	public ResourceBuilding waterbuildingscript;

	void OnAwake()
	{
		WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding");
		waterbuildingscript = WaterBuilding.GetComponent<ResourceBuilding>();
		Text = this.gameObject.GetComponent<TextMeshProUGUI>();
		waterbuildingscript.OnChange += UpdateUI;
	}

	public void UpdateUI()
	{
		Text.text = $"{waterbuildingscript.IncomeResources.Resource}";
	}
}
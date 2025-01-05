using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIFood : MonoBehaviour
{
	public GameObject FoodBuilding;
	public TextMeshProUGUI Text;
	public ResourceBuilding foodbuildingscript;

	void Start()
	{
		FoodBuilding = GameObject.FindGameObjectWithTag("FoodBuilding");
		foodbuildingscript = FoodBuilding.GetComponent<ResourceBuilding>();
		Text = this.gameObject.GetComponent<TextMeshProUGUI>();
		foodbuildingscript.OnChange += UpdateUI;
	}

	public void UpdateUI()
	{
		Text.text = $"{foodbuildingscript.IncomeResources.Resource}";
	}
}
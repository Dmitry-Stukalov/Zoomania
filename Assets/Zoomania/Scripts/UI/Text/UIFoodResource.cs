using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIFoodResource : UIResourceBase
{
	private FoodBuildingTimer Building { get; set; }

	//protected override void Start()
	//{
	//	base.Start();

	//	Building = GameObject.FindGameObjectWithTag("NewFood").GetComponent<FoodBuildingTimer>();
	//	Building.OnChange += UpdateUI;
	//}

	public void Initializing()
	{
		base.Start();

		Building = GameObject.FindGameObjectWithTag("NewFood").GetComponent<FoodBuildingTimer>();
		Building.OnChange += UpdateUI;
	}

	public override void UpdateUI()
	{
		Text.text = TextConversion(Building.IncomeResources.Resource);
	}
}
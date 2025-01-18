using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class UIResource : MonoBehaviour
{
	[field: SerializeField] private string BuildingName {  get; set; }
	private TextMeshProUGUI Text { get; set; }
	private ResourceBuilding resourcebuildingscript { get; set; }
	private MoneyPerClick moneyscript { get; set; }

	public void Start()
	{
		if (BuildingName == "FoodBuilding" || BuildingName == "WaterBuilding")
		{
			resourcebuildingscript = GameObject.FindGameObjectWithTag(BuildingName).GetComponent<ResourceBuilding>();
			resourcebuildingscript.OnChange += UpdateUI;
		}
		if (BuildingName == "Money")
		{
			moneyscript = GameObject.FindGameObjectWithTag(BuildingName).GetComponent<MoneyPerClick>();
			moneyscript.OnChange += UpdateUI;
		}

		Text = this.gameObject.GetComponent<TextMeshProUGUI>();
	}

	public void UpdateUI()
	{
		if (BuildingName == "FoodBuilding" || BuildingName == "WaterBuilding")
		{
			Text.text = TextConversion(resourcebuildingscript.IncomeResources.Resource);
		}
		if (BuildingName == "Money")
		{
			Text.text = TextConversion(moneyscript.IncomeMoney.Resource);
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

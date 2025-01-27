using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class UIResource : MonoBehaviour
{
	[field: SerializeField] private GameObject Building {  get; set; }
	private TextMeshProUGUI Text { get; set; }
	private ResourceBuilding resourcebuildingscript { get; set; }
	private MoneyPerClick moneyscript { get; set; }

	public void Start()
	{

		if (Building.tag == "FoodBuilding" || Building.tag == "WaterBuilding")
		{
			resourcebuildingscript = Building.GetComponent<ResourceBuilding>();
			resourcebuildingscript.OnChange += UpdateUI;
		}
		if (Building.tag == "Money")
		{
			moneyscript = Building.GetComponent<MoneyPerClick>();
			moneyscript.OnChange += UpdateUI;
		}

		Text = this.gameObject.GetComponent<TextMeshProUGUI>();
	}

	public void UpdateUI()
	{
		if (Building.tag == "FoodBuilding" || Building.tag == "WaterBuilding")
		{
			Text.text = TextConversion(resourcebuildingscript.IncomeResources.Resource);
		}
		if (Building.tag == "Money")
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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWaterResource : MonoBehaviour
{
	private ResourceBuilding Building { get; set; }
	private TextMeshProUGUI Text { get; set; }

	public void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();
		Building = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<ResourceBuilding>();
		Building.OnChange += UpdateUI;
	}

	public void UpdateUI()
	{
		Text.text = TextConversion(Building.IncomeResources.Resource);
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
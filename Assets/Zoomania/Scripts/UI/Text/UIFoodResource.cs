using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIFoodResource : MonoBehaviour
{
	private FoodCountBuffer foodbuffer { get; set; }
	private TextMeshProUGUI Text { get; set; }

	public void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();
		foodbuffer = GameObject.FindGameObjectWithTag("Background").GetComponent<FoodCountBuffer>();
		foodbuffer.OnChange += UpdateUI;

		UpdateUI();
	}

	public void UpdateUI()
	{
		Text.text = TextConversion(foodbuffer.GetFoodCount());
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
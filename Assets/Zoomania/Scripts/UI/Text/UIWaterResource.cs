using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWaterResource : MonoBehaviour
{
	private WaterCountBuffer waterbuffer { get; set; }
	private TextMeshProUGUI Text { get; set; }

	public void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();
		waterbuffer = GameObject.FindGameObjectWithTag("Background").GetComponent<WaterCountBuffer>();
		waterbuffer.OnChange += UpdateUI;

		UpdateUI();
	}

	public void UpdateUI()
	{
		Text.text = TextConversion(waterbuffer.GetWaterCount());
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
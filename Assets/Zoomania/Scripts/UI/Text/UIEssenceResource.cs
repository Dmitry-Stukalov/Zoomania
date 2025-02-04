using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UIEssenceResource : MonoBehaviour
{
	private Essence_Storage Building { get; set; }
	private TextMeshProUGUI Text { get; set; }


	public void Start()
	{
		Text = this.gameObject.GetComponent<TextMeshProUGUI>();
		Building = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Storage>();
		Building.OnChange += UpdateUI;
	}

	public void UpdateUI()
	{
		Text.text = TextConversion(Building.EssenceCount);
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

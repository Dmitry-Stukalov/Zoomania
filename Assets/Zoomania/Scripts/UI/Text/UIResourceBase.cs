using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIResourceBase : MonoBehaviour
{
	protected TextMeshProUGUI Text { get; set; }

	protected virtual void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();
	}

	public virtual void UpdateUI()
	{

	}

	protected string TextConversion(float value)
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
		if (value >= 1000000)
		{
			value /= 1000000;
			value = Mathf.Floor(value * 10) / 10;
			text = value.ToString() + "M";
			return text;
		}

		return null;
	}
}

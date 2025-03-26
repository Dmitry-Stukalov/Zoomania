using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopUpgradeButtonBase : MonoBehaviour, IPointerClickHandler
{
	protected Money Money { get; set; }
	protected TextMeshProUGUI Text {  get; set; }

	protected virtual void Start()
	{
		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

		Money = GameObject.FindGameObjectWithTag("Money").GetComponent<Money>();
	}

	protected virtual void UpdateData()
	{

	}

	public virtual void OnPointerClick(PointerEventData eventData)
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

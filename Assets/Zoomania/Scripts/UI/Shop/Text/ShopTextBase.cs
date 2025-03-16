using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopTextBase : MonoBehaviour
{
	protected TextMeshProUGUI Text {  get; set; }

	protected virtual void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();
	}

	protected virtual void UpdateData()
	{

	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopTextBase : MonoBehaviour
{
	[field: SerializeField] protected TextMeshProUGUI LevelNumber;
	protected TextMeshProUGUI Text {  get; set; }

	protected virtual void Start()
	{
		Text = gameObject.GetComponent<TextMeshProUGUI>();

		Text.text = "";
	}

	protected virtual void UpdateData()
	{

	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Buy_Food_Text : MonoBehaviour
{
	private TextMeshProUGUI Text { get; set; }


	public void Start()
	{
		Text = GetComponent<TextMeshProUGUI>();
		Text.text = " упить 10 ед. еды";
	}
}

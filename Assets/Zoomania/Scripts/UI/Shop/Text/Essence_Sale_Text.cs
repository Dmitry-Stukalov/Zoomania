using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Essence_Sale_Text : MonoBehaviour
{
	private GameObject Building { get; set; }
	private Essence_Storage Storage { get; set; }
	private TextMeshProUGUI Text { get; set; }


	public void Start()
	{
		Building = GameObject.FindGameObjectWithTag("Money");
		Storage = Building.GetComponent<Essence_Storage>();

		Text = GetComponent<TextMeshProUGUI>();

		Text.text = $"Количество эссенций: 0";
		Storage.OnChange += UpdateData;
	}

	public void UpdateData()
	{
		Text.text = $"Количество эссенций: {Storage.GetEssenceCount()}";
	}
}

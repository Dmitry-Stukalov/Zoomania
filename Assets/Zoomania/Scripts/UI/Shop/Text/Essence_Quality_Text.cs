using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Essence_Quality_Text : MonoBehaviour
{
	private GameObject Building { get; set; }
	private Essence_Quality EssenceQuality { get; set; }
	private TextMeshProUGUI Text { get; set; }


	public void Start()
	{
		Building = GameObject.FindGameObjectWithTag("Money");
		EssenceQuality = Building.GetComponent<Essence_Quality>();

		Text = GetComponent<TextMeshProUGUI>();

		Text.text = $"—тоимость эссенций: 1 -> 2\n";
		Text.text += $"Ёффективность кликов: -0 -> -0.5";

		EssenceQuality.OnUpgrade += UpdateData;
	}

	public void UpdateData()
	{
		Text.text = $"—тоимость эссенций: {EssenceQuality.CurrentLevel.EffectValue}\n";
		Text.text += $"Ёффективность кликов: -0.5";
	}
}

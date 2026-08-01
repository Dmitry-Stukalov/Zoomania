using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bushes_Text : ShopTextBase
{
	private Bushes Bushes { get; set; }

	/*protected override void Start()
	{
		base.Start();

		Bushes = GameObject.FindGameObjectWithTag("Background").GetComponent<Buy_Bushes>();

		Bushes.OnUpgrade += UpdateData;

		UpdateData();
	}

	protected override void UpdateData()
	{
		LevelNumber.text = Bushes.CurrentLevelData().CurrentLevelNumber.ToString();

		Text.text = $"Еда для панд: -{Bushes.CurrentLevelData().EffectValue}%\n";
	}*/
}

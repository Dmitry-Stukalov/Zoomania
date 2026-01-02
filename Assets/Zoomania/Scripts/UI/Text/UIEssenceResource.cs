using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class UIEssenceResource : UIResourceBase
{
	private Essence_Storage Building { get; set; }


	//protected override void Start()
	//{
	//	base.Start();

	//	Building = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Storage>();
	//	Building.OnChange += UpdateUI;
	//}

	public void Initializing()
	{
		base.Start();

		Building = GameObject.FindGameObjectWithTag("Money").GetComponent<Essence_Storage>();
		Building.OnChange += UpdateUI;
	}

	public override void UpdateUI()
	{
		Text.text = TextConversion(Building.EssenceCount);
	}
}

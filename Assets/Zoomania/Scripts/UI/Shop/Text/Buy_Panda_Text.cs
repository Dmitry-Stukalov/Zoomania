using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buy_Panda_Text : ShopTextBase
{
	private Barn Barn { get; set; }
	

	protected override void Start()
	{
		base.Start();

		Barn = GameObject.FindGameObjectWithTag("Barn").GetComponent<Barn>();
		Barn.Spawn += UpdateData;

		UpdateData();

		Text.text = "+1 случайная панда";
	}

	protected override void UpdateData()
	{
		LevelNumber.text = Barn.AnimalCount.ToString();
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Buy_Water_Text : ShopTextBase
{
	protected override void Start()
	{
		base.Start();

		Text.text = " упить 10 ед. воды";
	}
}

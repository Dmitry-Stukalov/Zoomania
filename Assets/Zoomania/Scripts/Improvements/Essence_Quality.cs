using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence_Quality : InitialImprovementBase
{
	private TakeEssenceClick EssenceClick { get; set; }



	protected override void Start()
	{
		base.Start();

		EssenceClick = GameObject.FindGameObjectWithTag("EssenceClick").GetComponent<TakeEssenceClick>();
	}

	public override void Upgrade()
	{
		base.Upgrade();

		EssenceClick.ChangeTimeSkip(0.3f, false);

		base.InvokeUpgrade();
	}
}

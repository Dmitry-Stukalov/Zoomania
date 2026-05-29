using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deep_Sleep : PurchaseImprovementBase
{
	private TakeEssenceClick EssenceClick { get; set; }


	public override void Initializing()
	{
		base.Initializing();

		EssenceClick = GameObject.FindGameObjectWithTag("EssenceClick").GetComponent<TakeEssenceClick>();
	}

	//protected override void Start()
	//{
	//	base.Start();

	//	EssenceClick = GameObject.FindGameObjectWithTag("EssenceClick").GetComponent<TakeEssenceClick>();
	//}

	public override void Upgrade()
	{
		base.Upgrade();

		EssenceClick.ChangeTimeSkip(CurrentLevel.EffectValue - levels_config.levels[CurrentLevel.CurrentLevelNumber - 1].EffectValue, true);

		base.InvokeUpgrade();
	}
}

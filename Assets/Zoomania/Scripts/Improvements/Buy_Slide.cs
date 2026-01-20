using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Buy_Slide : PurchaseImprovementBase                                                               //Поменять эффект после покупки
{
	[SerializeField] private TakeEssenceClick EssenceClick;
	[SerializeField] private List<GameObject> Slide;

	protected override void Start()
	{
		base.Start();

		for (int i = 0; i < Slide.Count; i++) Slide[i].SetActive(false);
	}

	public override void Upgrade()
	{
		base.Upgrade();


		Slide[CurrentLevel.CurrentLevelNumber - 1].SetActive(true);

		EssenceClick.ChangeTimeSkip(CurrentLevel.EffectValue - levels_config.levels[CurrentLevel.CurrentLevelNumber - 1].EffectValue, true);

		base.InvokeUpgrade();
	}
}
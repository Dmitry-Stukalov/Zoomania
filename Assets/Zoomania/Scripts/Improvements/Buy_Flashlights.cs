using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Buy_Flashlights : PurchaseImprovementBase																//Поменять эффект после покупки
{
	[SerializeField] private TakeEssenceClick EssenceClick;
	[SerializeField] private List<GameObject> Flashlights;

	protected override void Start()
	{
		base.Start();

		for (int i = 0; i < Flashlights.Count; i++) Flashlights[i].SetActive(false);
	}

	public override void Upgrade()
	{
		base.Upgrade();


		Flashlights[CurrentLevel.CurrentLevelNumber - 1].SetActive(true);

		EssenceClick.ChangeTimeSkip(CurrentLevel.EffectValue - levels_config.levels[CurrentLevel.CurrentLevelNumber - 1].EffectValue, true);

		base.InvokeUpgrade();
	}
}
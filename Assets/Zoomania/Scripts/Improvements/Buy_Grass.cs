using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Buy_Grass : PurchaseImprovementBase																//Поменять эффект после покупки
{
	[SerializeField] private TakeEssenceClick EssenceClick;
	[SerializeField] private List<GameObject> Grass;

	public override void Initializing()
	{
		base.Initializing();

		for (int i = CurrentLevel.CurrentLevelNumber; i < Grass.Count; i++) Grass[i].SetActive(false);
	}

	//protected override void Start()
	//{
	//	base.Start();

	//	for (int i = 0; i < Grass.Count; i++) Grass[i].SetActive(false);
	//}

	public override void Upgrade()
	{
		base.Upgrade();

		Grass[CurrentLevel.CurrentLevelNumber - 1].SetActive(true);

		EssenceClick.ChangeTimeSkip(CurrentLevel.EffectValue - levels_config.levels[CurrentLevel.CurrentLevelNumber - 1].EffectValue, true);

		base.InvokeUpgrade();
	}
}
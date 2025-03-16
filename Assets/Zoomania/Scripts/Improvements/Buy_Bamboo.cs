using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Buy_Bamboo : PurchaseImprovementBase																//Поменять эффект после покупки
{
	private TakeEssenceClick EssenceClick {  get; set; }
	private List<GameObject> Bamboo { get; set; }


	protected override void Start()
	{
		base.Start();

		EssenceClick = GameObject.FindGameObjectWithTag("EssenceClick").GetComponent<TakeEssenceClick>();

		Bamboo = new List<GameObject>();

		foreach (var bamboo in GameObject.FindGameObjectsWithTag("Bamboo"))
		{
			Bamboo.Add(bamboo);
			bamboo.SetActive(false);
		}
	}

	public override void Upgrade()
	{
		base.Upgrade();

		Bamboo[CurrentLevel.CurrentLevelNumber - 1].SetActive(true);

		EssenceClick.ChangeTimeSkip(CurrentLevel.EffectValue - levels_config.levels[CurrentLevel.CurrentLevelNumber - 1].EffectValue, true);

		base.InvokeUpgrade();
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Buy_Bamboo : PurchaseImprovementBase																//Поменять эффект после покупки
{
	[field: SerializeField] private List<GameObject> Bamboo1;
	[field: SerializeField] private List<GameObject> Bamboo2;
	[field: SerializeField] private List<GameObject> Bamboo3;
	[field: SerializeField] private List<GameObject> Bamboo4;
	[field: SerializeField] private List<GameObject> Bamboo5;
	[field: SerializeField] private List<GameObject> Bamboo6;
	private TakeEssenceClick EssenceClick;
	private List<GameObject> Bamboo;

	public override void Initializing()
	{
		/*base.Initializing();


		EssenceClick = GameObject.FindGameObjectWithTag("EssenceClick").GetComponent<TakeEssenceClick>();

		Bamboo = new List<GameObject>();

		foreach (var bamboo in GameObject.FindGameObjectsWithTag("Bamboo"))
		{
			Bamboo.Add(bamboo);
			bamboo.SetActive(false);
		}*/
	}

	//protected override void Start()
	//{
	//	base.Start();

	//	EssenceClick = GameObject.FindGameObjectWithTag("EssenceClick").GetComponent<TakeEssenceClick>();

	//	Bamboo = new List<GameObject>();

	//	foreach (var bamboo in GameObject.FindGameObjectsWithTag("Bamboo"))
	//	{
	//		Bamboo.Add(bamboo);
	//		bamboo.SetActive(false);
	//	}
	//}

	public override void Upgrade()
	{
		/*base.Upgrade();

		Bamboo[CurrentLevel.CurrentLevelNumber - 1].SetActive(true);

		EssenceClick.ChangeTimeSkip(CurrentLevel.EffectValue - levels_config.levels[CurrentLevel.CurrentLevelNumber - 1].EffectValue, true);

		base.InvokeUpgrade();*/
	}
}
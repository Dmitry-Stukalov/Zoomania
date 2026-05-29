using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Buy_Slide : PurchaseImprovementBase                                                               //Поменять эффект после покупки
{
	[SerializeField] private TakeEssenceClick EssenceClick;
	[SerializeField] private GameObject Slide;
	[SerializeField] private List<Sprite> Sprites;

	public override void Initializing()
	{
		base.Initializing();

		if (CurrentLevel.CurrentLevelNumber == 0) Slide.SetActive(false);
	}

	//protected override void Start()
	//{
	//	base.Start();

	//	Slide.SetActive(false);
	//}

	public override void Upgrade()
	{
		base.Upgrade();

		if (CurrentLevel.CurrentLevelNumber == 1) Slide.SetActive(true);
		else
		{
			Slide.GetComponent<SpriteRenderer>().sprite = Sprites[CurrentLevel.CurrentLevelNumber - 1];
		}

		EssenceClick.ChangeTimeSkip(CurrentLevel.EffectValue - levels_config.levels[CurrentLevel.CurrentLevelNumber - 1].EffectValue, true);

		base.InvokeUpgrade();
	}
}
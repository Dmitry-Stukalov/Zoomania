using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Buy_Pond : PurchaseImprovementBase                                                               //Поменять эффект после покупки
{
	[SerializeField] private TakeEssenceClick EssenceClick;
	[SerializeField] private GameObject Pond;
	[SerializeField] private List<Sprite> Sprites;

	protected override void Start()
	{
		base.Start();
	}

	public override void Upgrade()
	{
		base.Upgrade();

		if (CurrentLevel.CurrentLevelNumber == 1) Pond.SetActive(true);
		else
		{
			Pond.GetComponent<SpriteRenderer>().sprite = Sprites[CurrentLevel.CurrentLevelNumber - 1];
		}

		EssenceClick.ChangeTimeSkip(CurrentLevel.EffectValue - levels_config.levels[CurrentLevel.CurrentLevelNumber - 1].EffectValue, true);

		base.InvokeUpgrade();
	}
}
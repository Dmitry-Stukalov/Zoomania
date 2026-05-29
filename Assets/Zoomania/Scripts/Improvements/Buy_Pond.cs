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

	public override void Initializing()
	{
		base.Initializing();

		Pond.GetComponent<SpriteRenderer>().sprite = Sprites[CurrentLevel.CurrentLevelNumber];

		GameEvents.OnRequiredWaterSubstract?.Invoke((int)CurrentLevel.EffectValue);
		GameEvents.OnAnimalSpawn += () => StartCoroutine(SpawnAnimalPause());
	}

	private IEnumerator SpawnAnimalPause()
	{
		yield return new WaitForSeconds(0.5f);

		GameEvents.OnRequiredWaterSubstract?.Invoke((int)CurrentLevel.EffectValue);
	}

	//protected override void Start()
	//{
	//	base.Start();
	//}

	public override void Upgrade()
	{
		base.Upgrade();

		if (CurrentLevel.CurrentLevelNumber == 0) Pond.SetActive(true);
		else
		{
			Pond.GetComponent<SpriteRenderer>().sprite = Sprites[CurrentLevel.CurrentLevelNumber];
		}

		GameEvents.OnRequiredWaterSubstract?.Invoke((int)CurrentLevel.EffectValue);

		//EssenceClick.ChangeTimeSkip(CurrentLevel.EffectValue - levels_config.levels[CurrentLevel.CurrentLevelNumber - 1].EffectValue, true);

		base.InvokeUpgrade();
	}

	private void OnDisable()
	{
		GameEvents.OnAnimalSpawn -= () => GameEvents.OnRequiredWaterSubstract?.Invoke((int)CurrentLevel.EffectValue);
	}
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Buy_Bushes : PurchaseImprovementBase																//Поменять эффект после покупки
{
	[SerializeField] private TakeEssenceClick EssenceClick;
	[SerializeField] private List<GameObject> Bushes;

	public override void Initializing()
	{
		base.Initializing();

		for (int i = CurrentLevel.CurrentLevelNumber; i < Bushes.Count; i++) Bushes[i].SetActive(false);

		GameEvents.OnRequiredFoodSubstract?.Invoke((int)CurrentLevel.EffectValue);
		GameEvents.OnAnimalSpawn += () => StartCoroutine(SpawnAnimalPause());
	}

	private IEnumerator SpawnAnimalPause()
	{
		yield return new WaitForSeconds(0.5f);

		GameEvents.OnRequiredFoodSubstract?.Invoke((int)CurrentLevel.EffectValue);
	}

	//protected override void Start()
	//{
	//	base.Start();

	//	for (int i = 0; i < Bushes.Count; i++) Bushes[i].SetActive(false);
	//}

	public override void Upgrade()
	{
		base.Upgrade();

		Bushes[CurrentLevel.CurrentLevelNumber - 1].SetActive(true);

		GameEvents.OnRequiredFoodSubstract?.Invoke((int)CurrentLevel.EffectValue);
		//EssenceClick.ChangeTimeSkip(CurrentLevel.EffectValue - levels_config.levels[CurrentLevel.CurrentLevelNumber - 1].EffectValue, true);

		base.InvokeUpgrade();
	}

	private void OnDisable()
	{
		GameEvents.OnAnimalSpawn -= () => GameEvents.OnRequiredFoodSubstract?.Invoke((int)CurrentLevel.EffectValue);
	}
}
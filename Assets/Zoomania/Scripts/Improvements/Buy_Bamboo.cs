using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Buy_Bamboo : MonoBehaviour																	//Поменять эффект после покупки
{
	[field: SerializeField] private Improvement_Levels_Config_New improvement_levels_config { get; set; }
	private TakeEssenceClick EssenceClick {  get; set; }
	public Improvement_Level_New CurrentLevel { get; private set; }
	private List<GameObject> Bamboo { get; set; }

	public event Action OnUpgrade;


	public void Start()
	{
		EssenceClick = GameObject.FindGameObjectWithTag("EssenceClick").GetComponent<TakeEssenceClick>();

		CurrentLevel = improvement_levels_config.levels[0];

		Bamboo = new List<GameObject>();

		foreach (var bamboo in GameObject.FindGameObjectsWithTag("Bamboo"))
		{
			Bamboo.Add(bamboo);
			bamboo.SetActive(false);
		}
	}

	public void Upgrade()
	{
		CurrentLevel = improvement_levels_config.levels[CurrentLevel.CurrentLevelNumber + 1];

		Bamboo[CurrentLevel.CurrentLevelNumber - 1].SetActive(true);

		EssenceClick.ChangeTimeSkip(CurrentLevel.EffectValue - improvement_levels_config.levels[CurrentLevel.CurrentLevelNumber - 1].EffectValue, true);

		OnUpgrade?.Invoke();
	}

	public int GetLevelsCount()
	{
		return improvement_levels_config.levels.Count;
	}

	public Improvement_Level_New NextLevelData()
	{
		return improvement_levels_config.levels[CurrentLevel.CurrentLevelNumber + 1];
	}
}
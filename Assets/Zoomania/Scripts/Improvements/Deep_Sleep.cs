using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deep_Sleep : MonoBehaviour
{
	[field: SerializeField] private Improvement_Levels_Config_New improvement_levels_config { get; set; }
	private TakeEssenceClick EssenceClick { get; set; }
	public Improvement_Level_New CurrentLevel { get; private set; }

	public event Action OnUpgrade;


	public void Start()
	{
		EssenceClick = GameObject.FindGameObjectWithTag("EssenceClick").GetComponent<TakeEssenceClick>();

		CurrentLevel = improvement_levels_config.levels[0];
	}

	public void Upgrade()
	{
		CurrentLevel = improvement_levels_config.levels[CurrentLevel.CurrentLevelNumber + 1];

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

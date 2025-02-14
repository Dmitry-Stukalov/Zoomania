using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence_Quality : MonoBehaviour
{
	[field: SerializeField] private Improvement_Levels_Config_New levels_config { get; set; }
	public Improvement_Level_New CurrentLevel { get; set; }
	private TakeEssenceClick EssenceClick { get; set; }

	public event Action OnUpgrade;


	public void Start()
	{
		CurrentLevel = levels_config.levels[0];

		EssenceClick = GameObject.FindGameObjectWithTag("EssenceClick").GetComponent<TakeEssenceClick>();
	}

	public void Upgrade()
	{
		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];
		EssenceClick.ChangeTimeSkip(0.1f, false);

		OnUpgrade?.Invoke();
	}

	public Improvement_Level_New NextLevelData()
	{
		return levels_config.levels[CurrentLevel.CurrentLevelNumber];
	}

	public int GetLevelsCount()
	{
		return levels_config.levels.Count;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Barn_Cleaning : MonoBehaviour
{
	[field: SerializeField] private Improvement_Levels_Config improvement_levels_config { get; set; }
	public Improvement_Level CurrentLevel { get; private set; }
	private Barn BarnScript { get; set; }

	public event Action OnUpgrade;


	public void Start()
	{
		CurrentLevel = improvement_levels_config.levels[0];

		BarnScript = GetComponent<Barn>();
	}

	public void Upgrade()
	{
		CurrentLevel = improvement_levels_config.levels[CurrentLevel.CurrentLevelNumber + 1];

		BarnScript.MaxClicksToSpawn -= CurrentLevel.EffectValue;

		OnUpgrade?.Invoke();
	}

	public Improvement_Level NextLevelData()
	{
		return improvement_levels_config.levels[CurrentLevel.CurrentLevelNumber + 1];
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Buy_Bamboo : MonoBehaviour
{
	[field: SerializeField] private Improvement_Levels_Config improvement_levels_config { get; set; }
	public Improvement_Level CurrentLevel { get; private set; }
	private List<GameObject> Bamboo { get; set; }

	public event Action OnUpgrade;


	public void Start()
	{
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

		Bamboo[CurrentLevel.CurrentLevelNumber].SetActive(true);

		OnUpgrade?.Invoke();
	}

	public Improvement_Level NextLevelData()
	{
		return improvement_levels_config.levels[CurrentLevel.CurrentLevelNumber + 1];
	}
}
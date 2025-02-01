using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class HeadOfBarn : MonoBehaviour
{
	[field: SerializeField] private GameObject Barn { get; set; }
	[field: SerializeField] private Improvement_Levels_Config improvement_levels_config { get; set; }
	public Improvement_Level CurrentLevel { get; private set; }
	private Barn BarnScript { get; set; }
	public Timer Timer { get; set; }
	private PointerEventData data {  get; set; }

	public event Action OnUpgrade;

	public void Start()
	{
		CurrentLevel = improvement_levels_config.levels[0];

		BarnScript = Barn.GetComponent<Barn>();

		Timer = new Timer(CurrentLevel.MaxTime);

		Timer.OnTimerEnd += OnBarnClick;

		this.gameObject.SetActive(false);
	}

	public void OnBarnClick()
	{
		BarnScript.OnPointerClick(data, CurrentLevel.EffectValue);

		Timer.ResetTimer(false);
	}

	public void Upgrade()
	{
		CurrentLevel = improvement_levels_config.levels[CurrentLevel.CurrentLevelNumber+1];
		Timer.SetMaxTimeAndReset(CurrentLevel.MaxTime);

		OnUpgrade?.Invoke();
	}

	public Improvement_Level NextLevelData()
	{
		return improvement_levels_config.levels[CurrentLevel.CurrentLevelNumber+1];
	}

	public void Update()
	{
		Timer.Tick(Time.deltaTime);
	}
}

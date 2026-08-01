using NUnit.Framework;
using System;
using UnityEngine;
using System.Collections.Generic;

public class Improvement : MonoBehaviour, IImprovement, IUpgradable
{
	private ImprovementLevelsConfig _levelsConfig;
	public ImprovementLevel CurrentLevel { get; private set; }
	private CombinedEffects _effects = new CombinedEffects();


	public event Action OnUpgrade;

	public Improvement(ImprovementLevelsConfig levelsConfig)
	{
		_levelsConfig = levelsConfig;
	}

	public void Initializing()
	{
		CurrentLevel = _levelsConfig.levels[0];

		_effects.ApplyUpgrade(CurrentLevel);
	}

	public void Upgrade()
	{
		CurrentLevel = _levelsConfig.levels[CurrentLevel.CurrentLevelNumber];

		_effects.ApplyUpgrade(CurrentLevel);

		OnUpgrade?.Invoke();
	}

	public void AddEffect(IImprovementEffect effect) => _effects.AddEffect(effect);
}

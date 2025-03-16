using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialImprovementBase : ImprovementBase
{

	public event Action OnUpgrade;

	public virtual void Upgrade()
	{
		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];
	}

	protected void InvokeUpgrade() => OnUpgrade?.Invoke();

	public virtual int GetLevelsCount()
	{
		return levels_config.levels.Count;
	}

	public Improvement_Level_New CurrentLevelData()
	{
		return CurrentLevel;
	}

	public virtual Improvement_Level_New NextLevelData()
	{
		return levels_config.levels[CurrentLevel.CurrentLevelNumber];
	}
}

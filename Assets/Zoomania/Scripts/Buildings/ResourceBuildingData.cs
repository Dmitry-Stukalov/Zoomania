using System;
using UnityEngine;

public class ResourceBuildingData
{
	private BuildingLevelsConfig _levelsConfig;
	private ImprovementLevelsConfig _timeLevelsConfig;
	private ResourceType _resourceType;
	private BuildingLevel _currentLevel;
	private ImprovementLevel _currentTimeLevel;
	private IncomeResource _incomeResources;

	public ResourceBuildingData(BuildingLevelsConfig levelsConfig, ImprovementLevelsConfig timeLevelsConfig, ResourceType resourceType, BuildingLevel currentLevel, ImprovementLevel currentTimeLevel, IncomeResource incomeResources)
	{
		_levelsConfig = levelsConfig;
		_timeLevelsConfig = timeLevelsConfig;
		_resourceType = resourceType;
		_currentLevel = currentLevel;
		_currentTimeLevel = currentTimeLevel;
		_incomeResources = incomeResources;
	}

	public void Upgrade() => _currentLevel = _levelsConfig.levels[_currentLevel.CurrentLevelNumber + 1];

	public void AddResource(int value) => _incomeResources.CurrentResourceCount += value;

	public void UpgradeTime() => _currentTimeLevel = _timeLevelsConfig.levels[_currentTimeLevel.CurrentLevelNumber + 1];

	public void UpdateIncomeResourceData() => _incomeResources.ChangeIncomeValue(_currentLevel.IncomePerSecondValue);

	public void Update(float time) => _incomeResources.Update(time);
}

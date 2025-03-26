using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PurchaseImprovementBase : InitialImprovementBase
{
	public override void Upgrade()
	{
		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber + 1];
	}

	public override Improvement_Level_New NextLevelData()
	{
		return levels_config.levels[CurrentLevel.CurrentLevelNumber + 1];
	}

	public override async Task LoadData(int currentlevelnumber)
	{
		CurrentLevel = levels_config.levels[currentlevelnumber];
	}
}

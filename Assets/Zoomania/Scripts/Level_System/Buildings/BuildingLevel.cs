using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class BuildingLevel
{
	[field: SerializeField] public Sprite View { get; set; }
	[field: SerializeField] public int CurrentLevelNumber {  get; set; }
	[field: SerializeField] public int IncomePerSecondValue { get; set; }
	[field: SerializeField] public int IncomePerClickValue { get; set; }
	[field: SerializeField] public int MoneyForUpgrage { get; set; }

	/*public BuildingLevel(int currentlevel, int incomePerSecondValue, int incomePerClickValue, int moneyforupgrade)
	{
		CurrentLevelNumber = currentlevel;
		IncomePerSecondValue = incomePerSecondValue;
		IncomePerClickValue = incomePerClickValue;
		MoneyForUpgrage = moneyforupgrade;
	}*/
}

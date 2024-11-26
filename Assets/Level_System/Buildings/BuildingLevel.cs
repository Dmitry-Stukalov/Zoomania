using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingLevel
{
	public int CurrentLevelNumber {  get; set; }
	public int IncomePerSecondValue { get; set; }
	public int IncomePerClickValue { get; set; }
	public int MoneyForUpgrage {  get; set; }

	public BuildingLevel(int currentlevel, int incomePerSecondValue, int incomePerClickValue, int moneyforupgrade)
	{
		CurrentLevelNumber = currentlevel;
		IncomePerSecondValue = incomePerSecondValue;
		IncomePerClickValue = incomePerClickValue;
		MoneyForUpgrage = moneyforupgrade;
	}
}

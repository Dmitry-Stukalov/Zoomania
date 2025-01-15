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
	[field: SerializeField] public int DragResourceCapacity { get; set; }
	[field: SerializeField] public int MoneyForUpgrade { get; set; }

}

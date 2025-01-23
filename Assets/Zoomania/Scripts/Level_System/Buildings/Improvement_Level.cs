using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Improvement_Level
{
	[field: SerializeField] public Sprite View { get; set; }
	[field: SerializeField] public int CurrentLevelNumber { get; set; }
	[field: SerializeField] public int EffectValue { get; set; }
	[field: SerializeField] public int MoneyForUpgrade { get; set; }
	[field: SerializeField] public int MaxTime { get; set; }
}

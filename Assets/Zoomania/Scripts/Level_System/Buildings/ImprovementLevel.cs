using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ImprovementLevel
{
	[field: SerializeField] public Sprite View { get; set; }
	[field: SerializeField] public int CurrentLevelNumber { get; set; }
	[field: SerializeField] public float EffectValue { get; set; }
	[field: SerializeField] public int MoneyForUpgrade { get; set; }
}

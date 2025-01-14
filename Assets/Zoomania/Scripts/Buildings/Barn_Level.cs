using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Barn_Level
{
	[field: SerializeField] public Sprite View {  get; set; }
	[field: SerializeField] public int CurrentLevelNumber { get; set; }
	[field: SerializeField] public int ClicksAtTime { get; set; }
	[field: SerializeField] public int MoneyForUpgrade { get; set; }
}

using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


namespace Animal
{
	[Serializable]
	public class AnimalLevel
	{
		[field: SerializeField] public int Type { get; set; }
		[field: SerializeField] public int CurrentLevelNumber { get; set; }
		[field: SerializeField] public Sprite View { get; set; }
		[field: SerializeField] public RuntimeAnimatorController Animator { get; set; }
		[field: SerializeField] public int RequiredWater { get; set; }
		[field: SerializeField] public int RequiredFood { get; set; }
		[field: SerializeField] public int EssenceSpawnTimer { get; set; }
		[field: SerializeField] public int MoneyPerClick { get; set; }
		[field: SerializeField] public int MoneyPerSecond { get; set; }
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovementBase : MonoBehaviour
{
	[SerializeField] protected Improvement_Levels_Config_New levels_config;
	protected Improvement_Level_New CurrentLevel { get; set; }


	protected virtual void Start()
	{
		CurrentLevel = levels_config.levels[0];
	}
}

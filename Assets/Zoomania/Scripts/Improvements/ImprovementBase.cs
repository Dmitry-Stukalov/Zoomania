using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovementBase : MonoBehaviour
{
	[SerializeField] protected Improvement_Levels_Config_New levels_config;
	protected Improvement_Level_New CurrentLevel { get; set; }
	protected bool IsLoadData { get; set; } = false;


	//protected virtual void Start()
	//{
	//	if (!IsLoadData) CurrentLevel = levels_config.levels[0];
	//}

	public virtual void Initializing()
	{
		if (!IsLoadData) CurrentLevel = levels_config.levels[0];
	}
}

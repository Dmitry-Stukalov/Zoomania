using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepSleep : ImprovementBase
{
	[SerializeField] private TakeEssenceClick _essenceClick;

	protected override void AddImprovementEffect()
	{
		_improvement.AddEffect(new ChangeTimeSkipEffect(_essenceClick, true));
	}
}

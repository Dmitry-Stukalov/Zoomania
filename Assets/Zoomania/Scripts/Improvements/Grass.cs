using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//Поменять эффект после покупки
public class Grass : ImprovementBase
{
	[SerializeField] private TakeEssenceClick _essenceClick;
	[SerializeField] private List<GameObject> _grasses;

	protected override void AddImprovementEffect()
	{
		_improvement.AddEffect(new EnableObjectsEffect(_grasses));
		_improvement.AddEffect(new ChangeTimeSkipEffect(_essenceClick, true));
	}
}
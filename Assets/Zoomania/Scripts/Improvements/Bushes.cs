using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//Поменять эффект после покупки
public class Bushes : ImprovementBase
{
	[SerializeField] private List<GameObject> _bushes;

	protected override void AddImprovementEffect()
	{
		_improvement.AddEffect(new EnableObjectsEffect(_bushes));
	}
}
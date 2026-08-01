using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

//Поменять эффект после покупки
public class Pond : ImprovementBase
{
	[SerializeField] private SpriteRenderer _spriteRenderer;

	protected override void AddImprovementEffect()
	{
		_improvement.AddEffect(new ChangeSpriteEffect(_spriteRenderer));
	}
}
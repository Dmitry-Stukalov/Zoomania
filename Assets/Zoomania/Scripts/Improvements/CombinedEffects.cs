using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class CombinedEffects : IImprovementEffect
{
	private List<IImprovementEffect> _effects = new List<IImprovementEffect>();

	public void AddEffect(IImprovementEffect effect)
	{
		_effects.Add(effect);
	}

	public void ApplyUpgrade(ImprovementLevel newLevel)
	{
		foreach (var  effect in _effects) effect.ApplyUpgrade(newLevel);
	}
}

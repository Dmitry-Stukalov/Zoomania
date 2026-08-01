using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ImprovementBase : MonoBehaviour
{
	[SerializeField] protected ImprovementLevelsConfig _levelsConfig;
	protected Improvement _improvement;

	public virtual void Initializing()
	{
		_improvement = new Improvement(_levelsConfig);

		AddImprovementEffect();

		_improvement.Initializing();
	}

	protected abstract void AddImprovementEffect();

	public void Upgrade() => _improvement.Upgrade();
}

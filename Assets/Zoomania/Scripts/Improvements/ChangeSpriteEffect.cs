using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ChangeSpriteEffect : IImprovementEffect
{
	private SpriteRenderer _currentSprite;

	public ChangeSpriteEffect(SpriteRenderer currentSprite)
	{
		_currentSprite = currentSprite;
	}

	public void ApplyUpgrade(ImprovementLevel newLevel)
	{
		_currentSprite.sprite = newLevel.View;
	}
}

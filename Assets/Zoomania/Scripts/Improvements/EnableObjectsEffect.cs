using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class EnableObjectsEffect : IImprovementEffect
{
	private List<GameObject> _objects;
	
	public EnableObjectsEffect(List<GameObject> objects)
	{
		_objects = new List<GameObject>(objects);
	}

	public void ApplyUpgrade(ImprovementLevel newLevel)
	{
		int index = newLevel.CurrentLevelNumber - 1;

		if (index >= 0 && index < _objects.Count)
			_objects[index].SetActive(true);
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimalSpawner
{
	public IReadOnlyList<GameObject> Animals { get; }
	public int MoneyToSpawn { get; }
	public int AnimalCount { get; }

	public event Action Spawn;
}
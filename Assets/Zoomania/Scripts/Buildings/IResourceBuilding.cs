using System;
using UnityEngine;

public interface IResourceBuilding: IResourceStorage
{
	public BuildingLevel CurrentLevel { get; }
	public ImprovementLevel CurrentTimeLevel { get; }

	public event Action OnUpgrade;
}

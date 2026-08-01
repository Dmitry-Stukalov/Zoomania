using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

public static class GameEvents
{
	public static Action OnAnimalSpawn;
	public static Action<int, int> OnAlmanacUpdate;

	public static Action OnAutoClickOpen;

	public static Action<float> OnPandaEssenceMultiplyChange;

	public static Action<int> OnRequiredFoodSubstract;
	public static Action<int> OnRequiredWaterSubstract;

	private static readonly Dictionary<ResourceType, Action<int>> _resourceBuildingsEvents = new();

	/*public static void Subscribe(ResourceType resourceType, Action<int> listener)
	{
		if (!_resourceBuildingsEvents.ContainsKey(resourceType)) 
			_resourceBuildingsEvents[resourceType] = delegate { };

		_resourceBuildingsEvents[resourceType] += listener;
	}

	public static void Unsubscribe(ResourceType resourceType, Action<int> listener)
	{
		if (!_resourceBuildingsEvents.ContainsKey(resourceType)) 
			_resourceBuildingsEvents[resourceType] -= listener;
	}

	public static void SendResourceUpdate(ResourceType resourceType, int newCount)
	{
		if (_resourceBuildingsEvents.TryGetValue(resourceType, out var action))
			action?.Invoke(newCount);
	}*/
}

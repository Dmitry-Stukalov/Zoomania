using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveDataClass
{
	[SerializeField] private List<float> resources;
	[SerializeField] private List<int> buildinglevels;
	[SerializeField] private List<AnimalData> animals;

	public IReadOnlyList<float> Resources => resources;
	public IReadOnlyList<int> Buildinglevels => buildinglevels;
	public IReadOnlyList<AnimalData> Animals => animals;

	public void SetResoures(IReadOnlyList<float> allResources)
	{
		resources = new List<float>(allResources.Count);

		foreach (var resource in allResources)
		{
			resources.Add(resource);
		}
	}

	public void SetBuildingLevels(IReadOnlyList<int> allBuldingLevels)
	{
		buildinglevels = new List<int>(allBuldingLevels.Count);

		foreach (var buildinglevel in allBuldingLevels)
		{
			buildinglevels.Add(buildinglevel);
		}
	}

	public void SetAnimals(IReadOnlyList<AnimalData> allAnimals)
	{
		animals = new List<AnimalData>(allAnimals.Count);

		foreach (var animal in allAnimals)
		{
			animals.Add(animal);
		}
	}

	[Serializable]
	public struct AnimalData
	{
		public int Type;
		public int CurrentLevel;
		public float Water;
		public float Food;
		public float X;
		public float Y;
		public float Z;

		public AnimalData(int type, int currentlevel, float water, float food, float x, float y, float z)
		{
			Type = type; 
			CurrentLevel = currentlevel; 
			Water = water; 
			Food = food;
			X = x; 
			Y = y; 
			Z = z;
		}
	}
}

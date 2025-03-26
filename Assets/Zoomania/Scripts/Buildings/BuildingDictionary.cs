using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDictionary : MonoBehaviour
{
	[field: SerializeField] public List<string> BuildingsNames;
	[field: SerializeField] public List<MonoBehaviour> Buildings;
	public Dictionary<string, MonoBehaviour> BuildingsDictionary;

	private void Start()
	{
		BuildingsDictionary = new Dictionary<string, MonoBehaviour>();

		for (int i = 0; i < BuildingsNames.Count; i++)
		{
			BuildingsDictionary.Add(BuildingsNames[i], Buildings[i]);
		}
	}

	public Dictionary<string, MonoBehaviour> GetDictionary()
	{
		return BuildingsDictionary;
	}
}

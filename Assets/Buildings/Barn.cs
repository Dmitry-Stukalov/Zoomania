using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Barn : MonoBehaviour, IPointerClickHandler
{
	public GameObject Animal;

	public List<GameObject> Animals = new List<GameObject>();

	private GameObject SpawnZone;
	public IntStorage ClicksToSpawn { get; set; }
	public int MaxClicksToSpawn { get; set; } = 2;
	public int ClicksValueChange { get; set; } = 2;
	public int AnimalCount { get; set; } = 0;

	public event Action Spawn;

	public void Start()
	{
		ClicksToSpawn = new IntStorage(MaxClicksToSpawn);
		SpawnZone = GameObject.FindGameObjectWithTag("SpawnZone");
	}

	public void OnPointerClick(PointerEventData data)
	{
		ClicksToSpawn.SetValue(1, false);
		if (ClicksToSpawn.GetValue() == 0) SpawnAnimal();
	}

	public void SpawnAnimal()
	{
		Animals.Add(Instantiate(Animal, SpawnZone.transform.position, Quaternion.identity));
		AnimalCount++;
		MaxClicksToSpawn += ClicksValueChange;
		ClicksToSpawn.SetValue(MaxClicksToSpawn, true);
		
		Spawn?.Invoke();
	}
}

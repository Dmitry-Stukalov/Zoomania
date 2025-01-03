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
	public AudioSource Audio;
	public int ClicksToSpawn { get; set; }
	public int MaxClicksToSpawn { get; set; } = 2;
	public int ClicksValueChange { get; set; } = 2;
	public int AnimalCount { get; set; } = 0;

	public event Action Spawn;

	public void Start()
	{
		ClicksToSpawn = MaxClicksToSpawn;
		SpawnZone = GameObject.FindGameObjectWithTag("SpawnZone");
	}

	public void OnPointerClick(PointerEventData data)
	{
		ClicksToSpawn--;
		if (ClicksToSpawn == 0) SpawnAnimal();
		Audio.Play();
	}

	public void SpawnAnimal()
	{
		Animals.Add(Instantiate(Animal, SpawnZone.transform.position, Quaternion.identity));
		AnimalCount++;
		MaxClicksToSpawn += ClicksValueChange;
		ClicksToSpawn = MaxClicksToSpawn;
		
		Spawn?.Invoke();
	}
}

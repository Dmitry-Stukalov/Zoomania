using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Barn : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject Animal {  get; set; }
	[field: SerializeField] private AudioSource Audio { get; set; }
	[field: SerializeField] private TextMeshPro ClicksCount { get; set; }
	public List<GameObject> Animals { get; private set; }
	private GameObject SpawnZone { get; set; }
	
	private int ClicksToSpawn { get; set; }
	private int MaxClicksToSpawn { get; set; } = 2;
	private int ClicksValueChange { get; set; } = 2;
	public int AnimalCount { get; private set; } = 0;

	public event Action Spawn;

	public void Start()
	{
		Animals = new List<GameObject>();

		ClicksToSpawn = MaxClicksToSpawn;
		SpawnZone = GameObject.FindGameObjectWithTag("SpawnZone");
		UpdateText(ClicksToSpawn);
	}

	public void OnPointerClick(PointerEventData data)											//Срабатывает при нажатии. Уменьшает количество кликов требуемых для создания панды.
	{
		ClicksToSpawn--;
		UpdateText(ClicksToSpawn);
		if (ClicksToSpawn == 0) SpawnAnimal();
		Audio.Play();
	}

	public void SpawnAnimal()																	//Спавнит панду когда количество кликов требуемых для создания панды становится равным 0
	{
		Animals.Add(Instantiate(Animal, RandomSpawnPoint(), Quaternion.identity));
		AnimalCount++;
		MaxClicksToSpawn += ClicksValueChange;
		ClicksToSpawn = MaxClicksToSpawn;
		UpdateText(ClicksToSpawn);

		Spawn?.Invoke();
	}

	public Vector2 RandomSpawnPoint()
	{
		float randomX = UnityEngine.Random.Range(SpawnZone.transform.position.x - SpawnZone.transform.lossyScale.x / 2, SpawnZone.transform.position.x + SpawnZone.transform.lossyScale.x / 2);
		float randomY = UnityEngine.Random.Range(SpawnZone.transform.position.y - SpawnZone.transform.lossyScale.y / 2, SpawnZone.transform.position.y + SpawnZone.transform.lossyScale.y / 2);

		return new Vector2(randomX, randomY);
	}

	public void UpdateText(int count)
	{
		ClicksCount.text = count.ToString();
	}
}

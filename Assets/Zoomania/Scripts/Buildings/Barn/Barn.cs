using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Barn : MonoBehaviour, IAnimalSpawner
{
	[SerializeField] private PandaStorageConfig PandaStorageConfig;
	[SerializeField] private GameObject SpawnZone;
	public IReadOnlyList<GameObject> Animals => _animals;
	private List<GameObject> _animals = new List<GameObject>();
	public int MoneyToSpawn { get; private set; } = 0;
	public int AnimalCount { get; private set; } = 0;
	private int RandomNumber;

	public event Action Spawn;


	public void SpawnAnimal()																	//Спавнит панду (Сделать псевдорандомный алгоритм)
	{
		RandomNumber = UnityEngine.Random.Range(0, PandaStorageConfig.Animals.Count);

		_animals.Add(Instantiate(PandaStorageConfig.Animals[RandomNumber], RandomSpawnPoint(), Quaternion.identity));
		AnimalCount++;

		if (_animals.Count == 1) MoneyToSpawn += 50;
		else MoneyToSpawn *= 4;

		Spawn?.Invoke();
		GameEvents.OnAnimalSpawn?.Invoke();
		GameEvents.OnAlmanacUpdate?.Invoke(RandomNumber, 0);
	}

	public bool TakePandaData(int type, int level)
	{
		for (int i = 0; i < _animals.Count; i++)
			if (_animals[i].GetComponent<Animals>().CurrentLevel.Type == type && _animals[i].GetComponent<Animals>().CurrentLevel.CurrentLevelNumber == level) 
				return true;


		return false;
	}

	public Vector2 RandomSpawnPoint()
	{
		float randomX = UnityEngine.Random.Range(SpawnZone.transform.position.x - SpawnZone.transform.lossyScale.x / 2, SpawnZone.transform.position.x + SpawnZone.transform.lossyScale.x / 2);
		float randomY = UnityEngine.Random.Range(SpawnZone.transform.position.y - SpawnZone.transform.lossyScale.y / 2, SpawnZone.transform.position.y + SpawnZone.transform.lossyScale.y / 2);

		return new Vector2(randomX, randomY);
	}

	public async Task LoadData(IReadOnlyList<SaveDataClass.AnimalData> animals)
	{
		for (int i = 0; i < animals.Count; i++)
		{
			_animals.Add(Instantiate(PandaStorageConfig.Animals[animals[i].Type], RandomSpawnPoint(), Quaternion.identity));
			_animals[i].GetComponent<Animals>().LoadData(animals[i].CurrentLevel, animals[i].X, animals[i].Y, animals[i].Z);
			_animals[i].GetComponent<Animal_Feeding>().LoadData(animals[i].Water, animals[i].Food);
			AnimalCount++;

			GameEvents.OnAlmanacUpdate?.Invoke(i, animals[i].CurrentLevel - 1);

			if (_animals.Count == 1) MoneyToSpawn += 0;
			else MoneyToSpawn *= 4;
 
			Spawn?.Invoke();
		}
	}

}

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

public class Barn : MonoBehaviour
{
	[field: SerializeField] private Panda_Storage_Config Panda_Storage_Config { get; set; }
	[field: SerializeField] private GameObject SpawnZone { get; set; }
	public List<GameObject> Animals { get; private set; } = new List<GameObject>();
	public int MoneyToSpawn { get; set; } = 0;
	public int AnimalCount { get; private set; } = 0;
	private int RandomNumber { get; set; }

	public event Action Spawn;


	public void SpawnAnimal()																	//Спавнит панду
	{
		RandomNumber = UnityEngine.Random.Range(0, Panda_Storage_Config.Animals.Count);

		Animals.Add(Instantiate(Panda_Storage_Config.Animals[RandomNumber], RandomSpawnPoint(), Quaternion.identity));
		AnimalCount++;

		if (Animals.Count == 1) MoneyToSpawn += 0;
		else MoneyToSpawn *= 4;

		Spawn?.Invoke();
	}

	public void TakePanda(int place)
	{
		var animal = Panda_Storage_Config.Animals[0];

		Animals[place] = animal;
	}

	public void ReturnPanda(GameObject animal, int place)
	{
		Animals[place] = animal;
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
			Animals.Add(Instantiate(Panda_Storage_Config.Animals[animals[i].Type], RandomSpawnPoint(), Quaternion.identity));
			Animals[i].GetComponent<Animals>().LoadData(animals[i].CurrentLevel, animals[i].X, animals[i].Y, animals[i].Z);
			Animals[i].GetComponent<Animal_Feeding>().LoadData(animals[i].Water, animals[i].Food);
			AnimalCount++;

			if (Animals.Count == 1) MoneyToSpawn += 0;
			else MoneyToSpawn *= 4;
 
			Spawn?.Invoke();
		}
	}

}

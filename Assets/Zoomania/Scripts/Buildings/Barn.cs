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
	//[field: SerializeField] private GameObject Animal {  get; set; }
	[field: SerializeField] private AudioSource Audio { get; set; }
	[field: SerializeField] private TextMeshPro ClicksCount { get; set; }
	[field: SerializeField] private Barn_Levels_Config levels_config { get; set; }
	[field: SerializeField] private Panda_Storage_Config Panda_Storage_Config { get; set; }
	public Barn_Level CurrentLevel { get; private set; }
	public List<GameObject> Animals { get; private set; }
	private MoneyPerClick moneyperclick { get; set; }
	private GameObject SpawnZone { get; set; }
	private int ClicksToSpawn { get; set; }
	private int MaxClicksToSpawn { get; set; } = 10;
	private int ClicksValueChange { get; set; } = 5;
	public int AnimalCount { get; private set; } = 0;
	private int RandomNumber { get; set; }

	public event Action Spawn;
	public event Action OnLevelUp;

	public void Start()
	{
		CurrentLevel = levels_config.levels[0];
		this.gameObject.GetComponent<SpriteRenderer>().sprite = CurrentLevel.View;

		Animals = new List<GameObject>();

		ClicksToSpawn = MaxClicksToSpawn;
		SpawnZone = GameObject.FindGameObjectWithTag("SpawnZone");

		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();

		UpdateText(ClicksToSpawn);
	}

	public void OnPointerClick(PointerEventData data)											//—рабатывает при нажатии. ”меньшает количество кликов требуемых дл€ создани€ панды.
	{
		ClicksToSpawn -= CurrentLevel.ClicksAtTime;
		UpdateText(ClicksToSpawn);
		if (ClicksToSpawn <= 0) SpawnAnimal();
		Audio.Play();
	}

	public void SpawnAnimal()																	//—павнит панду когда количество кликов требуемых дл€ создани€ панды становитс€ равным 0
	{
		RandomNumber = UnityEngine.Random.Range(0, Panda_Storage_Config.Animals.Count);

		Animals.Add(Instantiate(Panda_Storage_Config.Animals[RandomNumber], RandomSpawnPoint(), Quaternion.identity));
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

	public void Upgrade()
	{
		if (moneyperclick.IncomeMoney.Resource < CurrentLevel.MoneyForUpgrade)
		{
			Debug.Log("Ќедостаточно монет");
			return;
		}

		moneyperclick.SetMoneyValue(CurrentLevel.MoneyForUpgrade);
		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];
		this.gameObject.GetComponent<SpriteRenderer>().sprite = CurrentLevel.View;
		OnLevelUp?.Invoke();
	}

	public Barn_Level NextLevelData()
	{
		if (CurrentLevel.CurrentLevelNumber <= levels_config.levels.Count-1) return levels_config.levels[CurrentLevel.CurrentLevelNumber];
		else return null;
	}	

	public void UpdateText(int count)
	{
		ClicksCount.text = count.ToString();
	}
}

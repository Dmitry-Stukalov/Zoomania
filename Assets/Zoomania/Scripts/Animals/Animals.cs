using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animals : MonoBehaviour
{
	[field: SerializeField] private AudioSource SoundLevelUp { get; set; }
	[field: SerializeField] private AudioSource SoundSpawn { get; set; }
	[field: SerializeField] private Panda_Levels_Config levels_config { get; set; }
	public AnimalLevel CurrentLevel { get; private set; }
	private GameObject Barn { get; set; }
	public bool InPersonalPaddock { get; private set; }
	private bool IsLoadData { get; set; } = false;

	public event Action LevelUp;
	public event Action ChangePaddock;


	public void Awake()
	{
		InPersonalPaddock = true;

		if (!IsLoadData)
		{
			CurrentLevel = levels_config.levels[0];

			levels_config.levels[0].IsOpen = true;

			gameObject.GetComponent<SpriteRenderer>().sprite = CurrentLevel.View;

			SoundSpawn.Play();
		}

		Barn = GameObject.FindGameObjectWithTag("Barn");

		ChangeParent(Barn, true);
	}

	public void Upgrade()                                                                   //Повышение уровня панды
	{
		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];
		levels_config.levels[CurrentLevel.CurrentLevelNumber - 1].IsOpen = true;
		gameObject.GetComponent<SpriteRenderer>().sprite = CurrentLevel.View;
		gameObject.GetComponent<Animator>().runtimeAnimatorController = CurrentLevel.Animator;

		SoundLevelUp.Play();

		LevelUp?.Invoke();
	}

	public void ChangeParent(GameObject newparent, bool flag)
	{
		transform.SetParent(newparent.transform, flag);

		if (InPersonalPaddock) InPersonalPaddock = false;
		else InPersonalPaddock = true;

		ChangePaddock?.Invoke();
	}

	public AnimalLevel CurrentLevelData()
	{
		return CurrentLevel;
	}

	public void LoadData(int levelnumber, float x, float y, float z)
	{
		IsLoadData = true;

		CurrentLevel = levels_config.levels[levelnumber - 1];
		gameObject.GetComponent<SpriteRenderer>().sprite = CurrentLevel.View;
		gameObject.GetComponent<Animator>().runtimeAnimatorController = CurrentLevel.Animator;
		LevelUp?.Invoke();
		transform.position = new Vector3(x, y, z);
	}
}

using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : MonoBehaviour												//Удалить закомментированное, если оно не нужно
{
	[field: SerializeField] private AudioSource SoundLevelUp { get; set; }
	[field: SerializeField] private AudioSource SoundSpawn { get; set; }

	[field: SerializeField] private Panda_Levels_Config levels_config { get; set; }
	public AnimalLevel CurrentLevel { get; private set; }
	private GameObject Barn { get; set; }
	public bool InPersonalPaddock { get; private set; }

	public event Action LevelUp;
	public event Action ChangePaddock;


	public void Start()
	{
		InPersonalPaddock = true;

		CurrentLevel = levels_config.levels[0];

		gameObject.GetComponent<SpriteRenderer>().sprite = CurrentLevel.View;

		Barn = GameObject.FindGameObjectWithTag("Barn");

		ChangeParent(Barn, true);

		SoundSpawn.Play();
	}

	public void Upgrade()                                                                   //Повышение уровня панды
	{
		CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];
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
}

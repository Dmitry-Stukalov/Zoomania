using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Animals : MonoBehaviour, IAnimal
{
	[field: SerializeField] private AudioSource SoundLevelUp { get; set; }
	[field: SerializeField] private AudioSource SoundSpawn { get; set; }
	[field: SerializeField] public PandaLevelsConfig LevelsConfig { get; private set; }
	public AnimalLevel CurrentLevel { get; private set; }
	public GameObject Barn { get; set; }
	public SpriteRenderer CurrentSprite { get; set; }
	public Animator CurrentAnimator { get; set; }
	public bool InPersonalPaddock { get; private set; }
	private bool IsLoadData = false;

	public event Action LevelUp;
	public event Action ChangePaddock;


	public void Start()
	{
		InPersonalPaddock = true;

		if (!IsLoadData)
		{
			CurrentLevel = LevelsConfig.levels[0];

			gameObject.GetComponent<SpriteRenderer>().sprite = CurrentLevel.View;

			SoundSpawn.Play();
		}

		Barn = GameObject.FindGameObjectWithTag("Barn");
		CurrentSprite = gameObject.GetComponent<SpriteRenderer>();
		CurrentAnimator = gameObject.GetComponent<Animator>();

		ChangeParent(Barn, true);
	}

	public void Upgrade()                                                                   //Повышение уровня панды
	{
		CurrentLevel = LevelsConfig.levels[CurrentLevel.CurrentLevelNumber];
		CurrentSprite.sprite = CurrentLevel.View;
		CurrentAnimator.runtimeAnimatorController = CurrentLevel.Animator;

		SoundLevelUp.Play();

		LevelUp?.Invoke();
	}

	public void ChangeParent(GameObject newParent, bool flag)
	{
		transform.SetParent(newParent.transform, flag);

		if (InPersonalPaddock) InPersonalPaddock = false;
		else InPersonalPaddock = true;

		ChangePaddock?.Invoke();
	}

	public void LoadData(int levelNumber, float x, float y, float z)
	{
		IsLoadData = true;

		CurrentLevel = LevelsConfig.levels[levelNumber - 1];

		if (CurrentSprite == null || CurrentAnimator == null)
		{
			CurrentSprite = gameObject.GetComponent<SpriteRenderer>();
			CurrentAnimator = gameObject.GetComponent<Animator>();
		}

		CurrentSprite.sprite = CurrentLevel.View;
		CurrentAnimator.runtimeAnimatorController = CurrentLevel.Animator;
		LevelUp?.Invoke();
		transform.position = new Vector3(x, y, z);
	}
}

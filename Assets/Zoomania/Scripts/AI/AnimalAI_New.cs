using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class AnimalAI_New : MonoBehaviour
{
	Animator animator { get; set; }
	private List<GameObject> MoveAreas {  get; set; } = new List<GameObject>();
	private ActionWalking_New AnimalWalking;
	private ActionResting AnimalResting = new ActionResting();
	private Animals Animal { get; set; }
	private int RandomAnimation { get; set; }
	private float RandomTime { get; set; }
	private int Action { get; set; }


	public bool IsDoAction { get; set; } = false;
	public bool InPersonalPaddock { get; set; } = false;

	public void Start()
	{
		animator = GetComponent<Animator>();

		foreach (var area in GameObject.FindGameObjectsWithTag("MovementArea"))
		{
			MoveAreas.Add(area);
		}

		AnimalWalking = new ActionWalking_New(MoveAreas);

		Animal = gameObject.GetComponent<Animals>();

		AnimalWalking.WalkingTime.OnTimerEnd += RandomActions;
		AnimalResting.RestingTime.OnTimerEnd += RandomActions;

		RandomActions();
	}

	public void RandomActions()                                                                                       //Рандомно выбирает действие для панды
	{
		if (!InPersonalPaddock)
		{

			AnimalWalking.IsMoving = false;
			AnimalResting.IsResting = false;

			animator.SetBool("IsMoving", false);
			animator.SetBool("IsMoving2", false);
			animator.SetBool("IsFlip", false);

			CancelInvoke();

			Action = UnityEngine.Random.Range(0, 15);

			if (Action >= 0 && Action <= 9)
			{
				RandomTime = UnityEngine.Random.Range(3, AnimalResting.RestingTime.MaxTime - 3);
				RandomAnimation = UnityEngine.Random.Range(1, 5);
				if (RandomAnimation == 1) animator.SetBool("IsFlip", true);


				IsDoAction = true;
				AnimalResting.Resting();
			}

			if (Action >= 10 && Action <= 15)
			{
				RandomAnimation = UnityEngine.Random.Range(1, 3);
				if (RandomAnimation == 1) animator.SetBool("IsMoving", true);
				if (RandomAnimation == 2) animator.SetBool("IsMoving2", true);

				IsDoAction = true;
				AnimalWalking.Walking(this.gameObject);
			}
		}
		else
		{
			CancelInvoke();

			AnimalWalking.IsMoving = false;
			AnimalResting.IsResting = false;

			animator.SetBool("IsMoving", false);
			animator.SetBool("IsMoving2", false);
			animator.SetBool("IsFlip", false);
		}
	}

	public void RandomAnimationOver()
	{
		animator.SetBool("IsFlip", false);
	}

	public void PersonalPaddock()
	{
		if (InPersonalPaddock)
		{
			InPersonalPaddock = false;
			RandomActions();
		}
		else
		{
			InPersonalPaddock = true;
			animator.SetBool("IsMoving", false);
			animator.SetBool("IsMoving2", false);
			CancelInvoke();
		}
	}

	public void Eating(bool flag)
	{
		if (flag) animator.SetBool("IsEat", true);
		else animator.SetBool("IsEat", false);
	}

	public void Update()                                                                                       //Запускает таймер у активного действия
	{
		if (!InPersonalPaddock)
		{
			if (AnimalWalking.IsMoving)
			{
				AnimalWalking.AnimalPosition = Vector2.MoveTowards(AnimalWalking.AnimalPosition, AnimalWalking.RandomPosition, AnimalWalking.Speed * Time.deltaTime);
				gameObject.transform.position = AnimalWalking.AnimalPosition;
				AnimalWalking.WalkingTime.Tick(Time.deltaTime);
			}
			if (AnimalResting.IsResting) AnimalResting.RestingTime.Tick(Time.deltaTime);
		}
	}
}
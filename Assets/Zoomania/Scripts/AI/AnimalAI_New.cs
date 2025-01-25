using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class AnimalAI_New : MonoBehaviour
{
	//Animator animator { get; set; }
	private List<GameObject> MoveAreas {  get; set; } = new List<GameObject>();
	private ActionWalking_New AnimalWalking;
	private ActionResting AnimalResting = new ActionResting();

	private int RandomAnimation {  get; set; }

	private Animals Animal { get; set; }
	private int Action { get; set; }


	public bool IsDoAction { get; set; } = false;
	public bool InPersonalPaddock { get; set; } = false;

	public void Start()
	{
		//animator = GetComponent<Animator>();

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

	public void OnDisable()
	{
		PersonalPaddock();
	}

	public void RandomActions()                                                                                       //Рандомно выбирает действие для панды
	{
		if (!InPersonalPaddock)
		{

			AnimalWalking.IsMoving = false;
			AnimalResting.IsResting = false;

			//animator.SetBool("IsMoving", false);
			//animator.SetBool("IsMoving2", false);

			CancelInvoke();

			Action = UnityEngine.Random.Range(0, 15);

			if (Action >= 0 && Action <= 6)
			{
				IsDoAction = true;
				AnimalResting.Resting();
			}

			if (Action >= 7 && Action <= 15)
			{
				/*RandomAnimation = UnityEngine.Random.Range(1, 3);
				if (RandomAnimation == 1) animator.SetBool("IsMoving", true);
				if (RandomAnimation == 2) animator.SetBool("IsMoving2", true);*/

				IsDoAction = true;
				AnimalWalking.Walking(this.gameObject);
			}
		}
		else
		{
			//animator.SetBool("IsMoving", false);
			//animator.SetBool("IsMoving2", false);
		}
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
			//animator.SetBool("IsMoving", false);
			//animator.SetBool("IsMoving2", false);
			CancelInvoke();
		}
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
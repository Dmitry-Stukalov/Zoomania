using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAI_New : MonoBehaviour
{
	private ActionWalking AnimalWalking;
	private ActionResting AnimalResting = new ActionResting();

	private Animals Animal { get; set; }
	private int Action { get; set; }


	public bool IsDoAction { get; set; } = false;
	public bool InPersonalPaddock { get; set; } = false;

	public void Start()
	{
		AnimalWalking = new ActionWalking(GameObject.FindGameObjectWithTag("MovementArea"));

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

			CancelInvoke();

			Action = UnityEngine.Random.Range(0, 15);

			if (Action >= 0 && Action <= 6)
			{
				IsDoAction = true;
				AnimalResting.Resting();
			}

			if (Action >= 7 && Action <= 15)
			{
				IsDoAction = true;
				AnimalWalking.Walking(this.gameObject);
			}
		}
	}

	public void Update()                                                                                       //Запускает таймер у активного действия
	{
		if (AnimalWalking.IsMoving)
		{
			AnimalWalking.AnimalPosition = Vector2.MoveTowards(AnimalWalking.AnimalPosition, AnimalWalking.RandomPosition, AnimalWalking.Speed * Time.deltaTime);
			gameObject.transform.position = AnimalWalking.AnimalPosition;
			AnimalWalking.WalkingTime.Tick(Time.deltaTime);
		}
		if (AnimalResting.IsResting) AnimalResting.RestingTime.Tick(Time.deltaTime);
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
			CancelInvoke();
		}
	}
}

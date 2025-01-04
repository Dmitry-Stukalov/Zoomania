using Animal;
using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnimalAI : MonoBehaviour
{
    private ActionWalking AnimalWalking;
    private ActionEating AnimalEating;
    private ActionResting AnimalResting = new ActionResting();

    private Animals Animal { get; set; }

    private int MandatoryEating { get; set; }
    private int Action { get; set; }

    public event Action OnTick;

    public bool IsDoAction = false;

    public void Start()
    {
		//AnimalWalking.MainCamera = Camera.main;
		//AnimalWalking.CalculateScreenBounds();
		
        AnimalWalking = new ActionWalking(GameObject.FindGameObjectWithTag("MovementArea"));

		Animal = gameObject.GetComponent<Animals>();
		AnimalEating = new ActionEating(Animal);

		AnimalWalking.WalkingTime.OnTimerEnd += RandomActions;
        AnimalEating.EatingTime.OnTimerEnd += RandomActions;
        AnimalResting.RestingTime.OnTimerEnd += RandomActions;

		/*MovementArea movementArea = FindObjectOfType<MovementArea>();
		if (movementArea != null)
		{
			AnimalWalking.MovementArea = movementArea;
		}*/

		RandomActions();
    }

    public void RandomActions()
    {
        AnimalWalking.IsMoving = false;
        AnimalEating.IsEating = false;
		AnimalEating.IsDrinking = false;
        AnimalResting.IsResting = false;

        CancelInvoke();

        if (MandatoryEating == 5) Action = UnityEngine.Random.Range(16, 22);
        else Action = UnityEngine.Random.Range(0, 22);

        if (Action >= 0 && Action <= 6)
        {
            IsDoAction = true;
			AnimalResting.Resting();
			MandatoryEating++;
        }

        if (Action >= 7 && Action <= 15)
        {
            IsDoAction = true;
            AnimalWalking.Walking(this.gameObject);
            MandatoryEating++;
        }

        if (Action >= 16 && Action <= 18)
        {
            IsDoAction = true;
            InvokeRepeating("Eating", 0f, 1f);
            MandatoryEating = 0;
        }

        if (Action >= 19 && Action <= 21)
        {
            IsDoAction = true;
			InvokeRepeating("Drinking", 0f, 1f);
			MandatoryEating = 0;
        }
    }


    public void Eating()
    {
        AnimalEating.Eating(true);
		return;
	}

    public void Drinking()
    {
		AnimalEating.Eating(false);
        return;
	}


    public void Update()
    {
        if (AnimalWalking.IsMoving)
        {
            AnimalWalking.AnimalPosition = Vector2.MoveTowards(AnimalWalking.AnimalPosition, AnimalWalking.RandomPosition, AnimalWalking.Speed);
            gameObject.transform.position = AnimalWalking.AnimalPosition;
            AnimalWalking.WalkingTime.Tick(Time.deltaTime);
        }

        if (AnimalEating.IsEating || AnimalEating.IsDrinking) 
            AnimalEating.EatingTime.Tick(Time.deltaTime);

        if (AnimalResting.IsResting) 
            AnimalResting.RestingTime.Tick(Time.deltaTime);

        OnTick?.Invoke();
    }
}
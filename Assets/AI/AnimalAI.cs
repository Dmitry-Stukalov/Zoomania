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

	public ActionWalking AnimalWalking = new ActionWalking();

	public Animals Animal { get; set; }
	private FoodBuilding foodbuilding { get; set; }
	private WaterBuilding waterbuilding { get; set; }
	private MoneyPerClick moneyperclick { get; set; }

	// Время задержки между действиями панды
	private Timer DoAction { get; set; } = new Timer(0);

	private int MandatoryEating {  get; set; }
	private int Action {  get; set; }

	public event Action OnTick;
	public event Action ActionEnd;

	// Флаги состояний
	public bool IsDoAction = false;
	public bool IsEating = false;
	public bool IsDrinking = false;

	// Стартовая функция
	public void Start()
	{
		AnimalWalking.MainCamera = Camera.main;
		AnimalWalking.CalculateScreenBounds();		// Рассчитываем границы экрана

		AnimalWalking.WalkingTime.OnTimerEnd += RandomActions;

		Animal = gameObject.GetComponent<Animals>();

		foodbuilding = GameObject.FindGameObjectWithTag("FoodBuilding").GetComponent<FoodBuilding>();
		waterbuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<WaterBuilding>();
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();

		DoAction.OnTimerEnd += RandomActions;
		DoAction.OnTimerEnd += IsHungry;

		RandomActions();
	}

	// Функция для расчета адаптивных границ экрана

	public void RandomActions()
	{
		AnimalWalking.IsMoving = false;
		IsEating = false;
		IsDrinking = false;

		CancelInvoke();

		if (MandatoryEating == 5) Action = UnityEngine.Random.Range(16, 22);
		else Action = UnityEngine.Random.Range(0, 22);

		if (Action >= 0 && Action <= 9)
		{
			IsDoAction = true;
			Resting();
			MandatoryEating++;
		}

		if (Action >= 10 && Action <= 15)
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

	public void Resting()
	{
		IsDoAction = true;
		DoAction.SetMaxTimeAndReset(UnityEngine.Random.Range(7, 10));
		Debug.Log("Панда отдыхает");
		return;
	}

	public void Eating()
	{
		if (IsEating == true)
		{
			foodbuilding.SetData(gameObject.GetComponent<Animals>().CurrentLevel.RequiredFood);

			return;
		}

		IsDoAction = true;
		IsEating = true;

		//if (foodbuilding.GetData() == 0) Animal.Hungry = true;
		//else Animal.Hungry = false;

		moneyperclick.UpdateDataSpawn();

		DoAction.SetMaxTimeAndReset(UnityEngine.Random.Range(3, 8));

		Debug.Log("Панда ест");
		return;
	}

	public void Drinking()
	{
		if (IsDrinking == true)
		{
			waterbuilding.SetData(gameObject.GetComponent<Animals>().CurrentLevel.RequiredWater);

			return;
		}

		IsDoAction = true;
		IsDrinking = true;

		//if (waterbuilding.GetData() == 0) Animal.Hungry = true;
		//else Animal.Hungry = false;

		moneyperclick.UpdateDataSpawn();

		DoAction.SetMaxTimeAndReset(UnityEngine.Random.Range(3, 8));

		Debug.Log("Панда пьет");
		return;
	}

	public void IsHungry()
	{
		if (IsDrinking || IsEating)
			if (waterbuilding.GetData() == 0 || foodbuilding.GetData() == 0) Animal.Hungry = true;
			else Animal.Hungry = false;
	}

	public void Update()
	{
		if (AnimalWalking.IsMoving)
		{
			AnimalWalking.AnimalPosition = Vector2.MoveTowards(AnimalWalking.AnimalPosition, AnimalWalking.RandomPosition, AnimalWalking.Speed);
			gameObject.transform.position = AnimalWalking.AnimalPosition;
			AnimalWalking.WalkingTime.Tick(Time.deltaTime);
		}
		
		DoAction.Tick(Time.deltaTime);

		OnTick?.Invoke();
	}
}
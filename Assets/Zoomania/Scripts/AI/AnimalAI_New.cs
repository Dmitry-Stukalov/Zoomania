using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Pool;

public class AnimalAI_New : MonoBehaviour														//нужно оптимизировать
{
	[field: SerializeField] GameObject Essence { get; set; }
	private GameObject essence { get; set; }
	private Day_And_Night Night { get; set; }
	private ObjectPool<GameObject> Pool { get; set; }
	private List<GameObject> MoveAreas {  get; set; }
	private ActionWalking AnimalWalking { get; set; }
	private ActionResting AnimalResting {get; set; }
	private Animals Animal { get; set; }
	private Animator animator { get; set; }
	private Timer SpawnEssence { get; set; }
	private int RandomAnimation { get; set; }
	private float RandomTime { get; set; }
	private int Action { get; set; }
	public bool IsDoAction { get; set; }
	public bool InPersonalPaddock { get; set; }
	public bool IsSleep { get; set; }


	public void Start()
	{
		IsDoAction = false;
		InPersonalPaddock = false;
		IsSleep = false;

		MoveAreas = new List<GameObject>();

		Animal = gameObject.GetComponent<Animals>();
		Animal.LevelUp += UpdateEssenceTimer;

		SpawnEssence = new Timer(Animal.CurrentLevel.EssenceSpawnTimer);
		SpawnEssence.OnTimerEnd += SpawnEssenceAction;

		Night = GameObject.FindGameObjectWithTag("Background").GetComponent<Day_And_Night>();
		Night.OnDay += WakeUp;
		Night.OnNight += Sleep;

		animator = GetComponent<Animator>();

		foreach (var area in GameObject.FindGameObjectsWithTag("MovementArea"))
		{
			MoveAreas.Add(area);
		}

		AnimalResting = new ActionResting();

		AnimalWalking = new ActionWalking(MoveAreas);

		AnimalWalking.WalkingTime.OnTimerEnd += RandomActions;
		AnimalResting.RestingTime.OnTimerEnd += RandomActions;

		Pool = new ObjectPool<GameObject>
		(
			createFunc: () => Instantiate(Essence, this.transform.position, Quaternion.identity),                          // Создание нового объекта
			actionOnGet: obj => obj.SetActive(true),							// Действие при получении объекта
			actionOnRelease: obj => obj.SetActive(false),						// Действие при возврате объекта
			actionOnDestroy: obj => Destroy(obj),                               // Действие при уничтожении объекта
			defaultCapacity: 1,                                                // Начальная емкость пула
			maxSize: 5                                                         // Максимальный размер пула
		);

		RandomActions();
	}


	public void RandomActions()                                                                                       //Рандомно выбирает действие для панды
	{
		if (!InPersonalPaddock)
		{
			if (!IsCanSleep())
			{
				AbortActions();

				Action = UnityEngine.Random.Range(0, 15);

				if (Action >= 0 && Action <= 12)
				{
					RandomTime = UnityEngine.Random.Range(3, AnimalResting.RestingTime.MaxTime - 3);
					RandomAnimation = UnityEngine.Random.Range(1, 5);
					if (RandomAnimation == 1) animator.SetBool("IsFlip", true);


					IsDoAction = true;
					AnimalResting.Resting();
				}

				if (Action >= 13 && Action <= 15)
				{
					RandomAnimation = UnityEngine.Random.Range(1, 2);
					if (RandomAnimation == 1) animator.SetBool("IsMoving", true);

					IsDoAction = true;
					AnimalWalking.Walking(this.gameObject);
				}
			}
			else
			{
				AbortActions();

				Debug.Log("Панда спит");
			}
		}
		else
		{
			AbortActions();
		}
	}

	public void AbortActions()
	{
		CancelInvoke();

		AnimalWalking.IsMoving = false;
		AnimalResting.IsResting = false;

		animator.SetBool("IsMoving", false);
		animator.SetBool("IsFlip", false);
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

			RandomActions();
		}
	}

	public void Eating(bool flag)
	{
		if (flag) animator.SetBool("IsEat", true);
		else animator.SetBool("IsEat", false);
	}

	public void SpawnEssenceAction()
	{
		essence = Pool.Get();
		essence.transform.SetParent(this.transform, true);
		essence.transform.position = transform.position;

		SpawnEssence.ResetTimer(false);
	}

	public void DestroyEssence(GameObject _essence)
	{
		Destroy(_essence);
	}

	public void Sleep()
	{
		IsSleep = true;

		RandomActions();
	}

	public void WakeUp()
	{
		IsSleep = false;

		RandomActions();
	}

	public bool IsCanSleep()
	{
		return !Night.IsDay;
	}

	public void ChangeTime(float value)
	{
		SpawnEssence.UpdateTimer(value);
	}

	public void UpdateEssenceTimer()
	{
		SpawnEssence.SetMaxTimeAndReset(Animal.CurrentLevel.EssenceSpawnTimer);
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

			if (IsSleep) SpawnEssence.Tick(Time.deltaTime);
		}
	}
}
using Animal;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Pool;

public class AnimalAI_New : MonoBehaviour
{
	[field: SerializeField] GameObject Essence { get; set; }
	private GameObject essence { get; set; }
	private Day_And_Night Night { get; set; }
	private ObjectPool<GameObject> Pool { get; set; }
	Animator animator { get; set; }
	private List<GameObject> MoveAreas {  get; set; } = new List<GameObject>();
	private ActionWalking_New AnimalWalking;
	private ActionResting AnimalResting = new ActionResting();
	private Animals Animal { get; set; }
	private int RandomAnimation { get; set; }
	private float RandomTime { get; set; }
	private int Action { get; set; }

	private Timer SpawnEssence { get; set; }

	public bool IsDoAction { get; set; } = false;
	public bool InPersonalPaddock { get; set; } = false;
	public bool IsSleep { get; set; } = false;

	public void Start()
	{
		SpawnEssence = new Timer(2);
		SpawnEssence.OnTimerEnd += SpawnEssenceAction;

		Night = GameObject.FindGameObjectWithTag("Background").GetComponent<Day_And_Night>();
		Night.DayChange += IsCanSlip;

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

		Pool = new ObjectPool<GameObject>
		(
			createFunc: () => Instantiate(Essence, this.transform.position, Quaternion.identity),                          // Создание нового объекта
			actionOnGet: obj => obj.SetActive(true),                            // Действие при получении объекта
			actionOnRelease: obj => obj.SetActive(false),                       // Действие при возврате объекта
			actionOnDestroy: obj => Destroy(obj),                               // Действие при уничтожении объекта
			defaultCapacity: 10,                                                // Начальная емкость пула
			maxSize: 20                                                         // Максимальный размер пула
		);
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

	public void IsCanSlip()
	{
		if (Night.IsDay)
		{
			IsSleep = false;
			SpawnEssence.ResetTimer(false);
		}
		else
		{
			IsSleep = true;
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

		if (IsSleep) SpawnEssence.Tick(Time.deltaTime);
	}
}
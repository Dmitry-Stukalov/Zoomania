using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

public class SpawnDragFoodResource : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject Resource { get; set; }
	[field: SerializeField] private GameObject AnimalPlace { get; set; }
	private ObjectPool<GameObject> Pool { get; set; }
	private AnimalAI_New Panda { get; set; }
	private AvailableFoodResource availableResources { get; set; }
	private GameObject resource { get; set; }
	public Camera mainCamera { get; set; }
	private Timer FeedTime { get; set; }
	private float Speed { get; set; }


	//public void Start()
	//{
	//	FeedTime = new Timer(1f);
	//	FeedTime.SetPause();

	//	FeedTime.OnTimerEnd += PandaDontEat;

	//	availableResources = GetComponent<AvailableFoodResource>();

	//	Initialize();
	//}

	//private void Initialize()
	//{
	//	Pool = new ObjectPool<GameObject>
	//	(
	//		createFunc: () => Instantiate(Resource, this.transform.position, Quaternion.identity),                          // Создание нового объекта
	//		actionOnGet: obj => obj.SetActive(true),                            // Действие при получении объекта
	//		actionOnRelease: obj => obj.SetActive(false),                       // Действие при возврате объекта
	//		actionOnDestroy: obj => Destroy(obj),                               // Действие при уничтожении объекта
	//		defaultCapacity: 8,                                             // Начальная емкость пула
	//		maxSize: 15                                                         // Максимальный размер пула
	//	);

	//	CreateFirstResources();
	//}

	public void Initializing()
	{
		FeedTime = new Timer(1f);
		FeedTime.SetPause();

		FeedTime.OnTimerEnd += PandaDontEat;

		availableResources = GetComponent<AvailableFoodResource>();

		Pool = new ObjectPool<GameObject>
		(
			createFunc: () => Instantiate(Resource, this.transform.position, Quaternion.identity),                          // Создание нового объекта
			actionOnGet: obj => obj.SetActive(true),                            // Действие при получении объекта
			actionOnRelease: obj => obj.SetActive(false),                       // Действие при возврате объекта
			actionOnDestroy: obj => Destroy(obj),                               // Действие при уничтожении объекта
			defaultCapacity: 8,                                             // Начальная емкость пула
			maxSize: 15                                                         // Максимальный размер пула
		);

		CreateFirstResources();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (AnimalPlace.transform.childCount == 0) return;

		Panda = AnimalPlace.GetComponentInChildren<AnimalAI_New>();

		FeedTime.ResetTimer(false);
		Panda.Eating(true);


		if (availableResources.FoodTimer.IncomeResources.Resource > 0)
		{

			mainCamera = Camera.main;

			resource = Pool.Get();
			resource.transform.SetParent(this.transform, true);
			resource.transform.position = transform.position;

			availableResources.UpdateDragResource();

			resource.GetComponent<FoodResource>().ChangeCapacity(availableResources.Food.GetCapacity());

			Speed = Random.Range(10f, 15f);

			resource.GetComponent<FoodResource>().FindAllPoints(AnimalPlace.transform.position, Speed);
			resource.GetComponent<FoodResource>().IsMove = true;

		}
	}

	public void CreateFirstResources()
	{
		for (int i = 0; i < 8; i++)
		{
			resource = Pool.Get();
			resource.transform.SetParent(this.transform, true);
			resource.transform.position = transform.position;
			Speed = Random.Range(10f, 15f);
			resource.GetComponent<FoodResource>().FindAllPoints(AnimalPlace.transform.position, Speed);
			resource.GetComponent<FoodResource>().IsMove = true;
		}
	}

	public void DestroyResource(GameObject _resource)
	{
		Pool.Release(_resource);
	}

	public void PandaDontEat()
	{
		Panda.Eating(false);
		FeedTime.ResetTimer(true);
	}

	public void Update()
	{
		FeedTime.Tick(Time.deltaTime);
	}
}

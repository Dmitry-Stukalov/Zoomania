using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

public class Spawn_Drag_Resource:MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject Resource { get; set; }
	[field: SerializeField] private GameObject AnimalPlace { get; set; }
	private ObjectPool<GameObject> Pool { get; set; }
	private AnimalAI_New Panda {  get; set; }
	private Available_Resources availableResources { get; set; }
	private GameObject resource { get; set; }
	public Camera mainCamera { get; set; }
	private Timer FeedTime { get; set; }
	private float Speed { get; set; }


	public void Start()
	{
		FeedTime = new Timer(1f);
		FeedTime.SetPause();

		FeedTime.OnTimerEnd += PandaDontEat;

		availableResources = this.GetComponent<Available_Resources>();

		Pool = new ObjectPool<GameObject>
		(
			createFunc: () => Instantiate(Resource, this.transform.position, Quaternion.identity),							// Создание нового объекта
			actionOnGet: obj => obj.SetActive(true),							// Действие при получении объекта
			actionOnRelease: obj => obj.SetActive(false),						// Действие при возврате объекта
			actionOnDestroy: obj => Destroy(obj),								// Действие при уничтожении объекта
			defaultCapacity: 8,												// Начальная емкость пула
			maxSize: 15															// Максимальный размер пула
		);

		CreateFirstResources();
	}

	public void OnPointerClick(PointerEventData eventData)
	{

		if (AnimalPlace.transform.childCount > 0)
		{
			Panda = AnimalPlace.GetComponentInChildren<AnimalAI_New>();

			FeedTime.ResetTimer(false);
			Panda.Eating(true);
		}

		if (availableResources.CurrentResources.IncomeResources.Resource > 0)
		{

			mainCamera = Camera.main;

			resource = Pool.Get();
			resource.transform.SetParent(this.transform, true);
			resource.transform.position = transform.position;

			availableResources.UpdateDragResource();

			resource.GetComponent<Resource_New>().ChangeCapacity(availableResources.Resource_New.GetCapacity());

			Speed = Random.Range(10f, 15f);

			resource.GetComponent<Resource_New>().FindAllPoints(AnimalPlace.transform.position, Speed);
			resource.GetComponent<Resource_New>().IsMove = true;

		}
	}

	public void CreateFirstResources()
	{
		for (int i = 0; i < 8;  i++)
		{
			resource = Pool.Get();
			resource.transform.SetParent(this.transform, true);
			resource.transform.position = transform.position;
			Speed = Random.Range(10f, 15f);
			resource.GetComponent<Resource_New>().FindAllPoints(AnimalPlace.transform.position, Speed);
			resource.GetComponent<Resource_New>().IsMove = true;
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

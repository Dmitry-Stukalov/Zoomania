using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

public class Spawn_Drag_Resource:MonoBehaviour/*, IBeginDragHandler, IDragHandler, IEndDragHandler*/, IPointerClickHandler
{
	[field: SerializeField] private GameObject Resource { get; set; }
	[field: SerializeField] private GameObject AnimalPlace { get; set; }
	private ObjectPool<GameObject> Pool { get; set; }
	private AnimalAI_New Panda {  get; set; }
	private Available_Resources availableResources { get; set; }
	private Vector3 offset { get; set; }
	private GameObject resource { get; set; }
	//private GameObject dragresource { get; set; }
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
			defaultCapacity: 10,												// Начальная емкость пула
			maxSize: 15															// Максимальный размер пула
		);
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

	/*public void OnBeginDrag(PointerEventData eventData)
	{
		if (availableResources.CurrentResources.IncomeResources.Resource > 0)
		{
			mainCamera = Camera.main;

			dragresource = Instantiate(Resource, this.transform.position, Quaternion.identity);
			dragresource.transform.SetParent(this.transform, true);

			availableResources.UpdateDragResource();

			dragresource.GetComponent<Resource_New>().ChangeCapacity(availableResources.Resource_New.GetCapacity());

			Vector3 mouseWorldPosition = GetMouseWorldPosition();
			offset = transform.position - mouseWorldPosition;
		}
	}*/

	/*public void OnDrag(PointerEventData eventData)
	{
		if (dragresource != null)
		{
			Vector3 mouseWorldPosition = GetMouseWorldPosition();
			dragresource.transform.position = mouseWorldPosition + offset;
		}
	}*/

	/*public void OnEndDrag(PointerEventData eventData)
	{
		if (dragresource != null)
		{
			availableResources.PutResource(dragresource.GetComponent<Resource_New>().TryFeedAnimal());
			Destroy(dragresource.gameObject);
		}
	}*/

	/*private Vector3 GetMouseWorldPosition()
	{
		Vector3 mouseScreenPosition = Input.mousePosition;
		mouseScreenPosition.z = 0f;
		return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
	}*/
}

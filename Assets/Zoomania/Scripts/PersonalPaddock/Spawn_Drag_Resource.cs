using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawn_Drag_Resource:MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
	[field: SerializeField] private GameObject Resource { get; set; }
	[field: SerializeField] private GameObject AnimalPlace { get; set; }
	//[field: SerializeField] private GameObject Parent { get; set; }
	private Available_Resources availableResources { get; set; }
	private Vector3 offset { get; set; }
	private List<GameObject> resources {  get; set; } = new List<GameObject>();
	private GameObject resource { get; set; }
	private GameObject dragresource { get; set; }
	public Camera mainCamera { get; set; }
	private float Speed { get; set; }


	public void Start()
	{
		availableResources = this.GetComponent<Available_Resources>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (availableResources.CurrentResources.IncomeResources.Resource > 0)
		{
			mainCamera = Camera.main;

			resource = Instantiate(Resource, this.transform.position, Quaternion.identity);
			resource.transform.SetParent(this.transform, true);

			availableResources.UpdateDragResource();

			resource.GetComponent<Resource_New>().ChangeCapacity(availableResources.Resource_New.GetCapacity());

			Speed = Random.Range(10f, 15f);

			resource.GetComponent<Resource_New>().FindAllPoints(AnimalPlace.transform.position, Speed);
			resource.GetComponent<Resource_New>().IsMove = true;
			resources.Add(resource);

		}
	}

	public void OnBeginDrag(PointerEventData eventData)
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
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (dragresource != null)
		{
			Vector3 mouseWorldPosition = GetMouseWorldPosition();
			dragresource.transform.position = mouseWorldPosition + offset;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (dragresource != null)
		{
			availableResources.PutResource(dragresource.GetComponent<Resource_New>().TryFeedAnimal());
			Destroy(dragresource.gameObject);
		}
	}

	private Vector3 GetMouseWorldPosition()
	{
		Vector3 mouseScreenPosition = Input.mousePosition;
		mouseScreenPosition.z = 0f;
		return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
	}
}

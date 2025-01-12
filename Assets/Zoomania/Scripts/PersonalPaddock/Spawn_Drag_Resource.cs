using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Spawn_Drag_Resource:MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	[field: SerializeField] private GameObject Resource { get; set; }
	private Available_Resources availableResources { get; set; }
	private Vector3 offset { get; set; }
	private GameObject resource {  get; set; }
	public Camera mainCamera { get; set; }
	private bool start { get; set; } = false;

	public void Start()
	{
		availableResources = this.GetComponent<Available_Resources>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (availableResources.CurrentResources.IncomeResources.Resource > 0)
		{
			mainCamera = Camera.main;
			resource = Instantiate(Resource, this.transform.position, Quaternion.identity);
			resource.transform.SetParent(this.transform, true);
			Vector3 mouseWorldPosition = GetMouseWorldPosition();
			offset = transform.position - mouseWorldPosition;

			availableResources.TakeResource();
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (resource != null)
		{
			Vector3 mouseWorldPosition = GetMouseWorldPosition();
			resource.transform.position = mouseWorldPosition + offset;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (resource != null)
		{
			availableResources.PutResource();
			Destroy(resource.gameObject);
		}
	}

	private Vector3 GetMouseWorldPosition()
	{
		Vector3 mouseScreenPosition = Input.mousePosition;
		mouseScreenPosition.z = 0f;
		return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
	}
}

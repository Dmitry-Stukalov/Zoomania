using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class DragAnimal : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	//private InputAction _touch;
	private Vector3 offset { get; set; }
	private Camera mainCamera { get; set; }
	public bool InPersonalPaddock { get; set; }

	public void Start()
	{
		//_touch = InputSystem.actions.FindAction("Click");

		InPersonalPaddock = false;

		mainCamera = Camera.main;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
        if (!InPersonalPaddock)
        {
			Vector3 mouseWorldPosition = GetMouseWorldPosition();
			offset = transform.position - mouseWorldPosition;

			//GetComponent<AnimalAI_New>().PersonalPaddock();
			GetComponent<AnimalAI_New>().BeginDragging();
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (!InPersonalPaddock)
		{
			Vector3 mouseWorldPosition = GetMouseWorldPosition();
			transform.position = mouseWorldPosition + offset;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (!InPersonalPaddock)
		{
			//GetComponent<AnimalAI_New>().PersonalPaddock();
			GetComponent<AnimalAI_New>().EndDragging();
		}
	}

	private Vector3 GetMouseWorldPosition()
	{
		Vector3 mouseScreenPosition = Input.mousePosition;
		mouseScreenPosition.z = 0f;
		return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
	}
}
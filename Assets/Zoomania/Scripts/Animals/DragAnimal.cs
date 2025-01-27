using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReplaceToPersonalPaddock : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
	private Vector3 offset { get; set; }
	private Camera mainCamera { get; set; }
	public bool InPersonalPaddock { get; set; } = false;

	public void Start()
	{
		mainCamera = Camera.main;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
        if (!InPersonalPaddock)
        {
			Vector3 mouseWorldPosition = GetMouseWorldPosition();
			offset = transform.position - mouseWorldPosition;

			GetComponent<AnimalAI_New>().PersonalPaddock();
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

	public void OnPointerUp(PointerEventData eventData)
	{
		GetComponent<AnimalAI_New>().PersonalPaddock();
	}

	private Vector3 GetMouseWorldPosition()
	{
		Vector3 mouseScreenPosition = Input.mousePosition;
		mouseScreenPosition.z = 0f;
		return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
	}

}

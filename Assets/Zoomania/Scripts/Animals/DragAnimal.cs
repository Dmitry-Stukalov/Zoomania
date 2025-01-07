using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReplaceToPersonalPaddock : MonoBehaviour, IPointerDownHandler, IDragHandler
{
	private Vector3 offset;
	private Camera mainCamera;

	public void Start()
	{
		mainCamera = Camera.main;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		Vector3 mouseWorldPosition = GetMouseWorldPosition();
		offset = transform.position - mouseWorldPosition;
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 mouseWorldPosition = GetMouseWorldPosition();
		transform.position = mouseWorldPosition + offset;
	}
	private Vector3 GetMouseWorldPosition()
	{
		Vector3 mouseScreenPosition = Input.mousePosition;
		mouseScreenPosition.z = 0f;
		return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
	}
}

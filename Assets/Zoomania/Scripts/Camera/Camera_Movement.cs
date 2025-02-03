using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
	public Camera mainCamera; // Ссылка на камеру
	private float panSpeed = 0.05f; // Скорость перемещения
	private Vector2 panLimitMin = new Vector2(-5, -2.25f); // Минимальные границы перемещения (x, y)
	private Vector2 panLimitMax = new Vector2(5, 2.25f); // Максимальные границы перемещения (x, y)

	private Vector3 lastTouchPosition; // Последняя позиция касания
	private bool isPanning = false; // Флаг для отслеживания состояния перемещения

	void Update()
	{
		if (Input.touchCount == 1) // Проверяем, есть ли одно касание
		{
			Touch touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Began)
			{
				lastTouchPosition = mainCamera.ScreenToWorldPoint(touch.position);
				isPanning = true;
			}
			if (touch.phase == TouchPhase.Moved && isPanning)
			{
				Vector3 currentTouchPosition = mainCamera.ScreenToWorldPoint(touch.position);
				Vector3 delta = lastTouchPosition - currentTouchPosition;

				// Перемещаем камеру
				Vector3 newPosition = mainCamera.transform.position + delta;
				newPosition.x = Mathf.Clamp(newPosition.x, panLimitMin.x, panLimitMax.x);
				newPosition.y = Mathf.Clamp(newPosition.y, panLimitMin.y, panLimitMax.y);

				mainCamera.transform.position = newPosition;

				lastTouchPosition = currentTouchPosition;
			}
			else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
			{
				isPanning = false;
			}
		}
	}
}

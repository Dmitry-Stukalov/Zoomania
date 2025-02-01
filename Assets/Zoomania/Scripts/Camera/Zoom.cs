using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
	public Camera camera; // Ссылка на камеру
	public float zoomSpeed = 0.001f; // Скорость зума
	public float minZoom = 0f; // Минимальный размер камеры (для ортографической камеры)
	public float maxZoom = 3f; // Максимальный размер камеры (для ортографической камеры)

	private Vector2 previousTouchDistance;

	void Update()
	{
		if (Input.touchCount == 2) // Проверяем, что на экране два касания
		{
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Вычисляем текущую дистанцию между касаниями
			Vector2 currentTouchDistance = touchZero.position - touchOne.position;
			float currentMagnitude = currentTouchDistance.magnitude;

			// Если это не первый кадр, вычисляем изменение дистанции
			if (previousTouchDistance != Vector2.zero)
			{
				float previousMagnitude = previousTouchDistance.magnitude;
				float deltaMagnitude = currentMagnitude - previousMagnitude;

				// Изменяем размер камеры в зависимости от изменения дистанции
				if (camera.orthographic)
				{
					camera.orthographicSize = Mathf.Clamp(camera.orthographicSize - deltaMagnitude * zoomSpeed, minZoom, maxZoom);
				}
				else
				{
					camera.fieldOfView = Mathf.Clamp(camera.fieldOfView - deltaMagnitude * zoomSpeed, minZoom, maxZoom);
				}
			}

			// Сохраняем текущую дистанцию для следующего кадра
			previousTouchDistance = currentTouchDistance;
		}
		else
		{
			// Сбрасываем предыдущую дистанцию, если касаний меньше двух
			previousTouchDistance = Vector2.zero;
		}
	}
}

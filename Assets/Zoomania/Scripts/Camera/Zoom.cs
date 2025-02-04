using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
	/*public Camera camera; // Ссылка на камеру
	private float zoomSpeed = 0.005f; // Скорость зума
	private float minZoom = 2.5f; // Минимальный размер камеры (для ортографической камеры)
	private float maxZoom = 5f; // Максимальный размер камеры (для ортографической камеры)

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
	}*/
	private Vector2 previousTouchPosition1; // Предыдущее положение первого касания
	private Vector2 previousTouchPosition2; // Предыдущее положение второго касания
	private bool isPanning; // Флаг для панорамирования

	private Camera cam;

	void Start()
	{
		cam = Camera.main;
	}

	void Update()
	{
		if (Input.touchCount == 2) // Проверяем, что на экране два пальца
		{
			Touch touch1 = Input.GetTouch(0);
			Touch touch2 = Input.GetTouch(1);

			// Если оба касания только начались, сохраняем их начальные позиции
			if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
			{
				previousTouchPosition1 = touch1.position;
				previousTouchPosition2 = touch2.position;
				isPanning = false;
			}
			else if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
			{
				// Вычисляем текущие позиции касаний
				Vector2 currentTouchPosition1 = touch1.position;
				Vector2 currentTouchPosition2 = touch2.position;

				// Проверяем, изменилось ли расстояние между пальцами (масштабирование)
				float previousDistance = Vector2.Distance(previousTouchPosition1, previousTouchPosition2);
				float currentDistance = Vector2.Distance(currentTouchPosition1, currentTouchPosition2);

				float distanceDelta = currentDistance - previousDistance;

				if (Mathf.Abs(distanceDelta) > 1f) // Если изменение расстояния значительное
				{
					ZoomCamera(distanceDelta * 0.01f); // Масштабируем камеру

					isPanning = false; // Отключаем панорамирование
				}
				else if (!isPanning) // Если расстояние между пальцами не изменилось, выполняем панорамирование
				{
					Vector2 delta1 = currentTouchPosition1 - previousTouchPosition1;
					Vector2 delta2 = currentTouchPosition2 - previousTouchPosition2;

					Vector3 averageDelta = (delta1 + delta2) * 0.5f; // Среднее смещение между двумя пальцами
					PanCamera(averageDelta);
					isPanning = true;
				}

				// Обновляем предыдущие позиции касаний
				previousTouchPosition1 = currentTouchPosition1;
				previousTouchPosition2 = currentTouchPosition2;
			}
		}
	}

	private void PanCamera(Vector3 delta)
	{
		Vector3 move = new Vector3(-delta.x, -delta.y, 0) * Time.deltaTime * cam.orthographicSize / Screen.height * 100f;
		cam.transform.Translate(move, Space.World);
	}

	private void ZoomCamera(float increment)
	{
		cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - increment, 2.5f, 5f); // Ограничиваем масштабирование
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
	public Camera mainCamera; // Ссылка на основную камеру
	public float zoomSpeed = 0.1f; // Скорость масштабирования
	public float minZoom = 2.0f; // Минимальный размер камеры
	public float maxZoom = 10.0f; // Максимальный размер камеры

	void Update()
	{
		// Проверяем, есть ли два касания на экране
		if (Input.touchCount == 2)
		{
			Touch touchZero = Input.GetTouch(0);
			Touch touchOne = Input.GetTouch(1);

			// Вычисляем расстояние между касаниями в предыдущем кадре
			Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
			Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

			float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
			float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

			// Разница между текущим и предыдущим расстояниями
			float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

			// Изменяем размер камеры (orthographicSize) для ортографической камеры
			if (mainCamera.orthographic)
			{
				mainCamera.orthographicSize += deltaMagnitudeDiff * zoomSpeed;
				mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minZoom, maxZoom);
			}
		}
	}
}

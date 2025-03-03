using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Camera cam;
	public float minZoom = 2f;
	private float maxZoom;
	public float zoomSpeed = 0.03f;
	public float moveSpeed = 0.009f;

	private Vector3 startPosition;
	private float startSize;
	private Vector3 lastTouchPosition;
	private bool isDraggingPanda = false;
	private Transform pandaTransform;

	private float camMinX, camMaxX, camMinY, camMaxY;

	private void Start()
	{
		startPosition = cam.transform.position;
		startSize = cam.orthographicSize;
		maxZoom = startSize;

		CalculateCameraBounds();
	}

	private void Update()
	{
		if (Input.touchCount == 2)
		{
			HandleZoom();
		}
		else if (Input.touchCount == 1)
		{
			HandleMovement();
		}
	}

	private void HandleZoom()
	{
		Touch touchZero = Input.GetTouch(0);
		Touch touchOne = Input.GetTouch(1);

		Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
		Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

		float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
		float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

		float difference = prevMagnitude - currentMagnitude;

		Zoom(difference * zoomSpeed);
	}

	private void Zoom(float increment)
	{
		float newSize = Mathf.Clamp(cam.orthographicSize + increment, minZoom, maxZoom);
		cam.orthographicSize = newSize;

		if (newSize >= maxZoom)
		{
			cam.transform.position = startPosition;
		}
		else
		{
			ClampCameraPosition();
		}
	}

	private void HandleMovement()
	{
		Touch touch = Input.GetTouch(0);

		if (touch.phase == TouchPhase.Began)
		{
			lastTouchPosition = touch.position;

			Ray ray = cam.ScreenPointToRay(touch.position);
			RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
			if (hit.collider != null && hit.collider.CompareTag("Panda"))
			{
				isDraggingPanda = true;
				pandaTransform = hit.collider.transform;
			}
			else
			{
				isDraggingPanda = false;
				pandaTransform = null;
			}
		}
		else if (touch.phase == TouchPhase.Moved && !isDraggingPanda)
		{
			Vector2 touchDelta = (Vector2)touch.position - (Vector2)lastTouchPosition;
			Vector3 move = new Vector3(-touchDelta.x * moveSpeed, -touchDelta.y * moveSpeed, 0);
			cam.transform.position += move;
			ClampCameraPosition();
			lastTouchPosition = touch.position;
		}

		if (isDraggingPanda && pandaTransform != null)
		{
			Vector3 pandaViewportPos = cam.WorldToViewportPoint(pandaTransform.position);

			if (pandaViewportPos.x < 0.1f || pandaViewportPos.x > 0.9f ||
				pandaViewportPos.y < 0.1f || pandaViewportPos.y > 0.9f)
			{
				Vector3 moveDirection = (pandaTransform.position - cam.transform.position).normalized;
				cam.transform.position += moveDirection * moveSpeed;
				ClampCameraPosition();
			}
		}

		if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
		{
			isDraggingPanda = false;
			pandaTransform = null;
		}
	}

	private void CalculateCameraBounds()
	{
		float aspectRatio = (float)Screen.width / Screen.height;
		float camWidth = startSize * aspectRatio;

		camMinX = startPosition.x - camWidth;
		camMaxX = startPosition.x + camWidth;
		camMinY = startPosition.y - startSize;
		camMaxY = startPosition.y + startSize;
	}

	private void ClampCameraPosition()
	{
		Vector3 pos = cam.transform.position;
		float aspectRatio = (float)Screen.width / Screen.height;
		float camWidth = cam.orthographicSize * aspectRatio;

		pos.x = Mathf.Clamp(pos.x, camMinX + camWidth, camMaxX - camWidth);
		pos.y = Mathf.Clamp(pos.y, camMinY + cam.orthographicSize, camMaxY - cam.orthographicSize);

		cam.transform.position = pos;
	}

}

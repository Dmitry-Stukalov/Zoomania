using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
	[field: SerializeField] private float ReferenceWidth;
	private Camera MainCamera { get; set; }
	private float AspectRatio { get; set; }
	private float OrtographicSize { get; set; }

	private void Start()
	{
		MainCamera = GetComponent<Camera>();

		AspectRatio = Screen.width / (float)Screen.height;

		MainCamera.orthographicSize = ReferenceWidth / (2 * AspectRatio);
	}

	private void Update()
	{
		MainCamera.orthographicSize = ReferenceWidth / (2 * AspectRatio);
	}
}

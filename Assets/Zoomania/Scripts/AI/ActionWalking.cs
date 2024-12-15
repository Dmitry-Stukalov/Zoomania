using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionWalking
{
	public Camera MainCamera { get; set; }
	public Vector2 ScreenBounds { get; set; }
	public Vector2 RandomPosition { get; set; }
	public Vector2 AnimalPosition { get; set; }
	public bool IsMoving { get; set; }
	public float Speed { get; set; } = 0.0005f;

	public Timer WalkingTime = new Timer(0);

	public void CalculateScreenBounds()
	{
		ScreenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
		return;
	}

	public Vector2 GetRandomPointWithinBounds()
	{
		float randomX = UnityEngine.Random.Range(-ScreenBounds.x, ScreenBounds.x);
		float randomY = UnityEngine.Random.Range(-ScreenBounds.y, ScreenBounds.y);
		return new Vector2(randomX, randomY);
	}

	public void Walking(GameObject animal)
	{
		IsMoving = true;
		AnimalPosition = new Vector2(animal.transform.position.x, animal.transform.position.y);
		RandomPosition = GetRandomPointWithinBounds();
		WalkingTime.SetMaxTimeAndReset(UnityEngine.Random.Range(3, 8));
		return;
	}
}
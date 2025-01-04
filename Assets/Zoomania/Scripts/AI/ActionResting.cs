using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionResting
{
	public Timer RestingTime = new Timer(0);

	public bool IsResting = false;

	public void Resting()
	{
		IsResting = true;
		Debug.Log("Панда отдыхает");
		RestingTime.SetMaxTimeAndReset(UnityEngine.Random.Range(7, 10));
	}
}

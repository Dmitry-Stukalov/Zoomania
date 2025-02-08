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
		RestingTime.SetMaxTimeAndReset(UnityEngine.Random.Range(8, 12));						//Продолжительность этого действия
	}
}

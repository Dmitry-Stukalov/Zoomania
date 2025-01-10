using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_New : MonoBehaviour
{
	public Sprite View { get; set; }
	private int Capacity { get; set; } = 1;

	public void ChangeCapacity(int new_capacity)
	{
		Capacity = new_capacity;
	}

	public int GetCapacity()
	{
		return Capacity;
	}
}
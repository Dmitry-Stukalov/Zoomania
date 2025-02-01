using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Mono_Save : MonoBehaviour
{
	private List<GameObject> Objects = new List<GameObject>();
	private Save GameSave = new Save();

	public void OnApplicationQuit()
	{
		foreach (var objects in GameObject.FindGameObjectsWithTag("Panda"))
		{
			Objects.Add(objects);
		}
	}
}

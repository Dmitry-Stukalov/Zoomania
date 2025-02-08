using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All_Objects : MonoBehaviour
{
	private List<GameObject> FirstScene { get; set; }
	private List<GameObject> SecondScene { get; set; }


	public void Start()
	{
		FirstScene = new List<GameObject>();
		SecondScene = new List<GameObject>();

		foreach(var objects in GameObject.FindGameObjectsWithTag("FirstScene"))
		{
			FirstScene.Add(objects);
		}

		foreach (var objects in GameObject.FindGameObjectsWithTag("SecondScene"))
		{
			SecondScene.Add(objects);
			objects.SetActive(false);
		}
	}

	public List<GameObject> FirstSceneObjects()
	{
		return FirstScene;
	}

	public List<GameObject> SecondSceneObjects()
	{
		return SecondScene;
	}
}
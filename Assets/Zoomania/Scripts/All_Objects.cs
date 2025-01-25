using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All_Objects : MonoBehaviour
{
	private List<GameObject> FirstScene = new List<GameObject>();
	private List<GameObject> SecondScene = new List<GameObject>();

	public void Start()
	{
		foreach (var objects in GameObject.FindGameObjectsWithTag("FirstScene"))
		{
			FirstScene.Add(objects);
		}

		foreach (var objects in GameObject.FindGameObjectsWithTag("SecondScene"))
		{
			SecondScene.Add(objects);
			objects.SetActive(false);
		}
	}

	public List<GameObject> GetFirstSceneObjects()
	{
		return FirstScene;
	}

	public List<GameObject> GetSecondSceneObjects()
	{
		return SecondScene;
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class To_Personal_Paddock : MonoBehaviour, IPointerClickHandler
{
	private List<GameObject> SecondScene = new List<GameObject>();

	public void Start()
	{
		foreach (var objects in GameObject.FindGameObjectsWithTag("SecondScene"))
		{
			SecondScene.Add(objects);
			objects.SetActive(false);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		for (int i = 0; i < SecondScene.Count; i++)
		{
			SecondScene[i].SetActive(true);
		}

		foreach (var objects in GameObject.FindGameObjectsWithTag("FirstScene"))
			objects.SetActive(false);
	}
}

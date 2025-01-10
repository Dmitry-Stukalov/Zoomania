using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class To_Personal_Paddock : MonoBehaviour, IPointerClickHandler
{
	private List<GameObject> FirstScene = new List<GameObject>();
	private List<GameObject> SecondScene = new List<GameObject>();

	public void OnPointerClick(PointerEventData eventData)
	{
		FirstScene = GameObject.FindGameObjectWithTag("Background").GetComponent<All_Objects>().GetFirstSceneObjects();
		SecondScene = GameObject.FindGameObjectWithTag("Background").GetComponent<All_Objects>().GetSecondSceneObjects();

		for (int i = 0; i < SecondScene.Count; i++)
		{
			SecondScene[i].SetActive(true);
		}

		for (int i = 0; i < FirstScene.Count; i++)
		{
			FirstScene[i].SetActive(false);
		}
	}
}

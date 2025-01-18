using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class To_Common_Paddock : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] GameObject CoinMenuResource { get; set; }
	[field: SerializeField] GameObject FoodMenuResource { get; set; }
	[field: SerializeField] GameObject WaterMenuResource { get; set; }

	private List<GameObject> FirstScene = new List<GameObject>();
	private List<GameObject> SecondScene = new List<GameObject>();

	public void OnPointerClick(PointerEventData eventData)
	{
		CoinMenuResource.GetComponent<Background_Resource>().SetAnimation();
		//FoodMenuResource.GetComponent<Background_Resource>().SetAnimation();
		//WaterMenuResource.GetComponent<Background_Resource>().SetAnimation();

		FirstScene = GameObject.FindGameObjectWithTag("Background").GetComponent<All_Objects>().GetFirstSceneObjects();
		SecondScene = GameObject.FindGameObjectWithTag("Background").GetComponent<All_Objects>().GetSecondSceneObjects();

		for (int i = 0; i < FirstScene.Count; i++)
		{
			FirstScene[i].SetActive(true);
		}

		for (int i = 0; i < SecondScene.Count; i++)
		{
			SecondScene[i].SetActive(false);
		}
	}
}

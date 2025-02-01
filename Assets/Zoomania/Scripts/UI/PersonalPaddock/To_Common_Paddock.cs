using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class To_Common_Paddock : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] GameObject CoinMenuResource { get; set; }
	[field: SerializeField] GameObject FoodMenuResource { get; set; }
	[field: SerializeField] GameObject WaterMenuResource { get; set; }

	private List<GameObject> FirstScene = new List<GameObject>();
	private List<GameObject> SecondScene = new List<GameObject>();
	private Camera maincamera { get; set; }

	public void Start()
	{
		maincamera = Camera.main;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		maincamera.transform.position = new Vector3(maincamera.transform.position.x + 23, maincamera.transform.position.y, maincamera.gameObject.transform.position.z);

		FirstScene = GameObject.FindGameObjectWithTag("Background").GetComponent<All_Objects>().GetFirstSceneObjects();
		SecondScene = GameObject.FindGameObjectWithTag("Background").GetComponent<All_Objects>().GetSecondSceneObjects();
		
		CoinMenuResource.GetComponent<Background_Resource>().SetAnimation();

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

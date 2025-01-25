using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class To_Personal_Paddock : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] GameObject WaterResource {  get; set; }
	[field: SerializeField] GameObject FoodResource { get; set; }
	[field: SerializeField] GameObject CoinMenuResource { get; set; }
	[field: SerializeField] GameObject FoodMenuResource { get; set; }
	[field: SerializeField] GameObject WaterMenuResource { get; set; }

	private List<GameObject> FirstScene = new List<GameObject>();
	private SpriteRenderer[] spriteRenderers;
	private List<GameObject> SecondScene = new List<GameObject>();

	public void OnPointerClick(PointerEventData eventData)
	{
		SceneManager.LoadSceneAsync("Region_Map", LoadSceneMode.Additive);


		CoinMenuResource.GetComponent<Background_Resource>().SetAnimation();

		FirstScene = GameObject.FindGameObjectWithTag("Background").GetComponent<All_Objects>().GetFirstSceneObjects();
		SecondScene = GameObject.FindGameObjectWithTag("Background").GetComponent<All_Objects>().GetSecondSceneObjects();

		for (int i = 0; i < SecondScene.Count; i++)
		{
			SecondScene[i].SetActive(true);
		}

		WaterResource.GetComponent<Available_Resources>().Initialize();
		FoodResource.GetComponent<Available_Resources>().Initialize();

		for (int i = 0; i < FirstScene.Count; i++)
		{
			//FirstScene[i].SetActive(false);
			if (FirstScene[i].transform.childCount > 0)
			{
				spriteRenderers = new SpriteRenderer[FirstScene[i].transform.childCount];
				spriteRenderers = FirstScene[i].GetComponentsInChildren<SpriteRenderer>();

				for (int j = 0; j < FirstScene[i].transform.childCount; j++)
				{
					spriteRenderers[j].enabled = false;
				}
			}
			else
			{
				if (FirstScene[i].layer == 5) FirstScene[i].GetComponent<Image>().enabled = false;
				else FirstScene[i].GetComponent<SpriteRenderer>().enabled = false;
			}

		}

	}
}

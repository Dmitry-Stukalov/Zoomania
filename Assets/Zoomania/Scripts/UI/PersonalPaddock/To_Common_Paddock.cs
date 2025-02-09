using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class To_Common_Paddock : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] GameObject CoinMenuResource { get; set; }
	[field: SerializeField] GameObject EssenceMenuResource { get; set; }
	private Camera maincamera { get; set; }
	private All_Objects Objects { get; set; }
	private List<GameObject> SecondScene { get; set; }

	public void Start()
	{
		Objects = GameObject.FindGameObjectWithTag("Background").GetComponent<All_Objects>();
		SecondScene = Objects.SecondSceneObjects();

		maincamera = Camera.main;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		maincamera.transform.position = new Vector3(maincamera.transform.position.x + 23, maincamera.transform.position.y, maincamera.gameObject.transform.position.z);
		
		CoinMenuResource.GetComponent<Background_Resource>().SetAnimation();
		EssenceMenuResource.GetComponent<Background_Resource>().SetAnimation();

		foreach (var objects in SecondScene)
		{
			objects.SetActive(false);
		}
	}
}

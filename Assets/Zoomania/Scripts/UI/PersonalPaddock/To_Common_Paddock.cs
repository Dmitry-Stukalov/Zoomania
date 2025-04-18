using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class To_Common_Paddock : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject Buttons;
	[field: SerializeField] private To_Personal_Paddock PersonalPaddock;
	private Camera maincamera { get; set; }
	private All_Objects Objects { get; set; }
	private List<GameObject> SecondScene { get; set; }

	public void Start()
	{
		Objects = GameObject.FindGameObjectWithTag("Background").GetComponent<All_Objects>();

		maincamera = Camera.main;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		PersonalPaddock.InPersonalPaddock = false;

		SecondScene = Objects.SecondSceneObjects();
		maincamera.transform.position = new Vector3(maincamera.transform.position.x + 23, maincamera.transform.position.y, maincamera.gameObject.transform.position.z);

		foreach (var objects in SecondScene)
		{
			objects.SetActive(false);
		}

		if (!Buttons.activeSelf) Buttons.SetActive(true);
	}
}
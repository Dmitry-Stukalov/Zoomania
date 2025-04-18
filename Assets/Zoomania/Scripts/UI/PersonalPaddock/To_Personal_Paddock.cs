using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class To_Personal_Paddock : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject Buttons;
    private Camera maincamera { get; set; }
	private All_Objects Objects { get; set; }
	private List<GameObject> SecondScene {  get; set; }
	public bool InPersonalPaddock { get; set; }

	public void Start()
	{
		Objects = GameObject.FindGameObjectWithTag("Background").GetComponent<All_Objects>();

		maincamera = Camera.main;

		InPersonalPaddock = false;
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        InPersonalPaddock = true;

        if (Buttons.activeSelf) Buttons.SetActive(false);

        if (maincamera != null)
        {
            maincamera.orthographicSize = 5;
            maincamera.transform.position = new Vector3(-23, 0, -20);
        }

        SecondScene = Objects.SecondSceneObjects();

        foreach (var obj in SecondScene)
        {
            obj.SetActive(true);
        }
    }
}

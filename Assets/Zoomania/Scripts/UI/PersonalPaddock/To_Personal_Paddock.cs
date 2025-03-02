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
	[field: SerializeField] GameObject CoinMenuResource { get; set; }
	[field: SerializeField] GameObject EssenceMenuResource { get; set; }
	private Camera maincamera { get; set; }
	private All_Objects Objects { get; set; }
	private List<GameObject> SecondScene {  get; set; }

    private CameraController cameraController;

    public void Start()
	{
		Objects = GameObject.FindGameObjectWithTag("Background").GetComponent<All_Objects>();

		maincamera = Camera.main;

        cameraController = maincamera.GetComponent<CameraController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (maincamera != null)
        {
            maincamera.orthographicSize = 5; 
            maincamera.transform.position = new Vector3(-23, 0, -20); 
        }

        SecondScene = Objects.SecondSceneObjects();

        CoinMenuResource.GetComponent<Background_Resource>().SetAnimation();
        EssenceMenuResource.GetComponent<Background_Resource>().SetAnimation();

        foreach (var obj in SecondScene)
        {
            obj.SetActive(true);
        }
    }

}

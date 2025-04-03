using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScoreSection : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] public GameObject OpenShopSection;
	[field: SerializeField] public GameObject CloseShopSection;
	[field: SerializeField] public Scrollbar ScrollBar;
	[field: SerializeField] public bool IsCellSection;
	private PointerEventData _pointerEventData;

	public void Start()
	{
		if (IsCellSection) OnPointerClick(_pointerEventData);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		ScrollBar.value = 1;
		OpenShopSection.SetActive(true);
		CloseShopSection.SetActive(false);
	}
}

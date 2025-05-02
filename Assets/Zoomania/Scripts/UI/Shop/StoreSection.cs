using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreSection : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject OpenShopSection;
	[field: SerializeField] private GameObject CloseShopSection;
	[field: SerializeField] private Scrollbar ScrollBar;
	[field: SerializeField] private bool IsCellSection;
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

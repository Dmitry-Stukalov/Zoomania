using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickOnButtonPanel : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject Button;
	private ButtonPanel ButtonPanel { get; set; }

	private void Start()
	{
		ButtonPanel = Button.GetComponent<ButtonPanel>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		ButtonPanel.OpenClose();
	}
}

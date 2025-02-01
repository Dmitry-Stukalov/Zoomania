using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click_Feed_Area : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject Icon;

	public void OnPointerClick(PointerEventData eventData)
	{
		Icon.GetComponent<Spawn_Drag_Resource>().OnPointerClick(eventData);
	}
}
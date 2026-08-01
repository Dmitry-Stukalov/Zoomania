using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickWaterArea : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject Icon;

	public void OnPointerClick(PointerEventData eventData)
	{
		//Icon.GetComponent<SpawnDragWaterResource>().OnPointerClick(eventData);
	}
}

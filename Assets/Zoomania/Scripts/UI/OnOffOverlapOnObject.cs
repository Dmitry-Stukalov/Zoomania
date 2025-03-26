using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnOffOverlapOnObject : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] GameObject Overlap1;
	[field: SerializeField] GameObject Overlap2;

	public void OnPointerClick(PointerEventData eventData)
	{
		//Overlap1.GetComponent<OnOffOverlap>().ChangeOverlapActive();
		//Overlap2.GetComponent<OnOffOverlap>().ChangeOverlapActive();
	}
}

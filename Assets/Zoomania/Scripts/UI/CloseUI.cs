using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloseUI : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject UI;
	private RobustUIToggle UIState;

	public void Start()
	{
		UI.TryGetComponent(out UIState);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		UIState.OnPointerClick(eventData);
	}
}

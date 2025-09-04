using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContinueButton : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject Background;
	[field: SerializeField] private GameObject NextTutorial;

	public event Action OnDestroy;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (NextTutorial != null) NextTutorial.SetActive(true);

		OnDestroy?.Invoke();
		Destroy(Background);
	}

	public void BackgroundDeactivate()
	{
		Background.SetActive(false);
	}
}

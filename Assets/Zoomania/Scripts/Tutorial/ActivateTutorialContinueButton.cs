using UnityEngine;
using UnityEngine.EventSystems;

public class ActivateTutorialContinueButton : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject ContinueObject;
	private ContinueButton continueButton;

	private void Start()
	{
		if (ContinueObject != null) continueButton = ContinueObject.GetComponentInChildren<ContinueButton>();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (continueButton != null && ContinueObject.activeSelf) continueButton.OnPointerClick(eventData);
		Destroy(gameObject.GetComponent<ActivateTutorialContinueButton>());
	}
}

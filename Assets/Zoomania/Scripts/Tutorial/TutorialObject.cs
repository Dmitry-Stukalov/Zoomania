using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TutorialObject : MonoBehaviour, ICanvasRaycastFilter
{
	private RectTransform TargetTransform { get; set; }
	[field: SerializeField] private RectTransform AllowedTransform { get; set; }
	private Image image { get; set; }
	private ContinueButton continueButton { get; set; }
	private PointerEventData EventData { get; set; }


	private void Start()
	{
		TargetTransform = GetComponent<RectTransform>();
		image = GetComponent<Image>();

		continueButton = GetComponentInChildren<ContinueButton>();
	}


	public bool IsRaycastLocationValid(Vector2 ScreenPoint, Camera eventCamera)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(AllowedTransform, ScreenPoint, eventCamera, out Vector2 localPoint);;

		return !AllowedTransform.rect.Contains(localPoint);
	}
}

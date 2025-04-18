using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[field: SerializeField] private Sprite UnPress;
	[field: SerializeField] private Sprite Press;
	[field: SerializeField] private GameObject Text;
	[field: SerializeField] private GameObject Icon;
	[field: SerializeField] private GameObject ButtonMask;

	public void Start()
	{
		gameObject.GetComponent<Image>().sprite = UnPress;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (ButtonMask.activeSelf) return;

        gameObject.GetComponent<Image>().sprite = Press;
		Text.transform.position = new Vector3(Text.transform.position.x, Text.transform.position.y - 5f, Text.transform.position.z);
		Icon.transform.position = new Vector3(Icon.transform.position.x, Icon.transform.position.y - 5f, Icon.transform.position.z);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (ButtonMask.activeSelf) return;

		gameObject.GetComponent<Image>().sprite = UnPress;
		Text.transform.position = new Vector3(Text.transform.position.x, Text.transform.position.y + 5f, Text.transform.position.z);
		Icon.transform.position = new Vector3(Icon.transform.position.x, Icon.transform.position.y + 5f, Icon.transform.position.z);
	}

}

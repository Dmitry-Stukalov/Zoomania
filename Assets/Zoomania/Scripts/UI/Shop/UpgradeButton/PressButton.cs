using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PressButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[field: SerializeField] private Sprite UnPress {  get; set; }
	[field: SerializeField] private Sprite Press { get; set; }
	[field: SerializeField] private GameObject Text {  get; set; }
	[field: SerializeField] private GameObject Icon { get; set; }

	public void Start()
	{
		gameObject.GetComponent<Image>().sprite = UnPress;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		gameObject.GetComponent<Image>().sprite = Press;
		Text.transform.position = new Vector3(Text.transform.position.x, Text.transform.position.y - 5f, Text.transform.position.z);
		Icon.transform.position = new Vector3(Icon.transform.position.x, Icon.transform.position.y - 5f, Icon.transform.position.z);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		gameObject.GetComponent<Image>().sprite = UnPress;
		Text.transform.position = new Vector3(Text.transform.position.x, Text.transform.position.y + 5f, Text.transform.position.z);
		Icon.transform.position = new Vector3(Icon.transform.position.x, Icon.transform.position.y + 5f, Icon.transform.position.z);
	}

}

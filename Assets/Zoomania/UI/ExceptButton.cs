using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExceptButton : MonoBehaviour, IPointerClickHandler
{
	public GameObject NonMoney;

	public void OnPointerClick(PointerEventData data)
	{
		NonMoney.SetActive(true);
	}
}

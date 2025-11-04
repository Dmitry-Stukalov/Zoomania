using UnityEngine;
using UnityEngine.EventSystems;

public class LootBoxBackground : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject CloseAnimalBackground;
	[field: SerializeField] private GameObject _LootBoxBackground;

	public void OnPointerClick(PointerEventData eventData)
	{
		CloseAnimalBackground.SetActive(true);
		_LootBoxBackground.SetActive(false);
	}
}

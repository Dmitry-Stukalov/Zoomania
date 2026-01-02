using UnityEngine;
using UnityEngine.EventSystems;

public class LootBoxBackground : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private GameObject _LootBoxBackground;
	[SerializeField] private GameObject LootBoxGameObject;
	[SerializeField] private LootBox _LootBox;

	public void OnPointerClick(PointerEventData eventData)
	{
		_LootBoxBackground.SetActive(false);
		_LootBox.LootBoxAppearance();
		LootBoxGameObject.SetActive(true);
	}
}

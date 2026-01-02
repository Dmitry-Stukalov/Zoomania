using UnityEngine;
using UnityEngine.EventSystems;

public class LootBoxAppearance : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject LootBoxBackground;

	public void OpenLootBox()
	{
		LootBoxBackground.SetActive(true);
		//Time.timeScale = 0;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		OpenLootBox();
	}
}

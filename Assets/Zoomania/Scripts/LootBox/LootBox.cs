using UnityEngine;
using UnityEngine.EventSystems;

public class LootBox : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject CloseAnimalBackground;
	[field: SerializeField] private int ClicksCount;
	[field: SerializeField] private ParticleSystem Particles;
	[field: SerializeField] private BlockButtons Shop;

	public void OnPointerClick(PointerEventData eventData)
	{
		ClicksCount--;
		Particles.Play();

		if (ClicksCount == 0) OpenLootBox();
	}

	private void OpenLootBox()
	{
		ClicksCount = 10;
		Shop.ToggleMenu();
		CloseAnimalBackground.SetActive(false);
	}
}

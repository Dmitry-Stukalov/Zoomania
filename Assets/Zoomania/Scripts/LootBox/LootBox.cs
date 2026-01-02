using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LootBox : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject CloseAnimalBackground;
	[SerializeField] private GameObject Animal;
	[field: SerializeField] private int ClicksCount;
	[field: SerializeField] private ParticleSystem Particles;
	[field: SerializeField] private BlockButtons Shop;

	private void Start()
	{
		LootBoxAppearance();
	}

	public void LootBoxAppearance()
	{
		Animal.SetActive(false);
	}

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
		gameObject.SetActive(false);
		Animal.SetActive(true);
	}
}

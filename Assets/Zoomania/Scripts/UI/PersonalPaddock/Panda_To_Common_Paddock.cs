using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panda_To_Common_Paddock : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] private GameObject AnimalPlace { get; set; }
	[field: SerializeField] private GameObject Barn { get; set; }
	[field: SerializeField] private GameObject Fence { get; set; }

	private Animals_New Panda { get; set; }
	private AnimalAI_New PandaAI { get; set; }
	private ReplaceToPersonalPaddock PandaPP { get; set; }
	private Animal_Feeding PandaAF { get; set; }



	public void OnPointerClick(PointerEventData eventData)
	{
		if (AnimalPlace.transform.childCount != 0)
		{
			Panda = AnimalPlace.GetComponentInChildren<Animals_New>();
			PandaAI = AnimalPlace.GetComponentInChildren<AnimalAI_New>();
			PandaPP = AnimalPlace.GetComponentInChildren<ReplaceToPersonalPaddock>();
			PandaAF = AnimalPlace.GetComponentInChildren<Animal_Feeding>();

			Panda.ChangeParent(Barn, false);

			float randomX = UnityEngine.Random.Range(Fence.transform.position.x - Fence.transform.localScale.x / 2, Fence.transform.position.x + Fence.transform.localScale.x / 2);
			float randomY = UnityEngine.Random.Range(Fence.transform.position.y - Fence.transform.localScale.y / 2, Fence.transform.position.y + Fence.transform.localScale.y / 2);

			Panda.transform.position = new Vector2(randomX, randomY);

			PandaAI.PersonalPaddock();
			PandaPP.InPersonalPaddock = false;

			PandaAF.ChangeVisibility();
		}
	}

}

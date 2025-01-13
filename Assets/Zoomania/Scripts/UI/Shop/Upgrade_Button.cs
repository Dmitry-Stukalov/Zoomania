using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using static Unity.Collections.AllocatorManager;

public class Upgrade_Button : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] public ResourceBuilding resourceBuiding { get; set; }
	private TextMeshProUGUI Text { get; set; }

	void Start()
	{
		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

		UpdateData();
	}

	public void OnPointerClick(PointerEventData data)
	{
		resourceBuiding.LevelUp();

		UpdateData();
	}

	public void UpdateData()
	{
		if (resourceBuiding.CurrentLevel.CurrentLevelNumber == 10) this.gameObject.SetActive(false);
		Text.text = resourceBuiding.CurrentLevel.MoneyForUpgrage.ToString();
	}
}
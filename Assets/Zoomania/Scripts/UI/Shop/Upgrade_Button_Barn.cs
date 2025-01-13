using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Upgrade_Button_Barn : MonoBehaviour, IPointerClickHandler
{
	[field: SerializeField] public Barn Barn { get; set; }
	private TextMeshProUGUI Text { get; set; }

	void Start()
	{
		Text = gameObject.GetComponentInChildren<TextMeshProUGUI>();

		UpdateData();
	}

	public void OnPointerClick(PointerEventData data)
	{
		Barn.Upgrade();

		UpdateData();
	}

	public void UpdateData()
	{
		if (Barn.CurrentLevel.CurrentLevelNumber == 3) this.gameObject.SetActive(false);
		Text.text = Barn.CurrentLevel.MoneyForUpgrade.ToString();
	}
}

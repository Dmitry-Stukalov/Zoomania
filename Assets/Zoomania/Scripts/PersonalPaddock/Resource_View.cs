using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Resource_View : MonoBehaviour
{
	[field: SerializeField] private GameObject ResourceBuilding{ get; set; }
	private Available_Resources CurrentResources { get; set; }
	private TextMeshPro Text;

	public void Start()
	{
		CurrentResources = ResourceBuilding.GetComponent<Available_Resources>();
		Text = this.gameObject.GetComponent<TextMeshPro>();
		CurrentResources.OnChange += UpdateUI;
		UpdateUI();
	}

	public void UpdateUI()
	{
		Text.text = $"{CurrentResources.CurrentResources.IncomeResources.Resource}";
	}
}

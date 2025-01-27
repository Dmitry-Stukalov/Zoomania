using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Available_Water_Resources : MonoBehaviour
{
	private BuildingLevel CurrentLevelData { get; set; }
	public ResourceBuilding CurrentResources { get; set; }
	[field: SerializeField] private GameObject ResourceBuilding { get; set; }
	[field: SerializeField] private GameObject Resource { get; set; }
	public Resource_New Resource_New { get; private set; }
	private bool start { get; set; } = false;
	private bool someresources { get; set; } = false;


	public event Action OnChange;

	public void Initialize()
	{
		if (!start)
		{
			CurrentResources = GameObject.FindGameObjectWithTag("Background").GetComponent<WaterCountBuffer>().WaterBuildingScript;
			Resource_New = Resource.GetComponent<Resource_New>();
			Resource_New.ChangeCapacity(CurrentResources.DragResourceValue());

			CurrentResources.OnLevelUp += UpdateData;

			start = true;
		}
		OnChange?.Invoke();
	}

	public void UpdateDragResource()
	{
		if (someresources)
		{
			UpdateData();
			someresources = false;
		}

		if (Resource_New.GetCapacity() > CurrentResources.IncomeResources.Resource) TakeSomeResource();
		else TakeResource();

		OnChange?.Invoke();
		CurrentResources.Change();
	}

	private void UpdateData()
	{
		Resource_New.ChangeCapacity(CurrentResources.DragResourceValue());
		OnChange?.Invoke();
	}

	public void TakeResource()
	{
		CurrentResources.IncomeResources.Resource -= Resource_New.GetCapacity();

		OnChange?.Invoke();
		CurrentResources.Change();
	}

	public void TakeSomeResource()
	{
		Resource_New.ChangeCapacity(CurrentResources.IncomeResources.Resource);
		CurrentResources.IncomeResources.Resource -= Resource_New.GetCapacity();
		someresources = true;
	}

	public void PutResource(int value)
	{
		CurrentResources.IncomeResources.Resource += value;
		OnChange?.Invoke();
		CurrentResources.Change();
	}
}
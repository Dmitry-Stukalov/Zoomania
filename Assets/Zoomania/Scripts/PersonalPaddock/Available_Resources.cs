using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Available_Resources : MonoBehaviour
{
	private BuildingLevel CurrentLevelData { get; set; }
	public ResourceBuilding CurrentResources { get; set; }
	[field: SerializeField] private string ResourceBuildingName { get; set; }
	private int DragResourceCapacity { get; set; }
	private bool start { get; set; } = false;
	private bool someresources { get; set; } = false;


	public event Action OnChange;

	public void Initialize()
	{
		if (!start)
		{
			CurrentResources = GameObject.FindGameObjectWithTag(ResourceBuildingName).GetComponent<ResourceBuilding>();
			DragResourceCapacity = CurrentResources.DragResourceValue();
			CurrentResources.OnLevelUp += UpdateData;

			start = true;
		}
		OnChange?.Invoke();
	}

	private void UpdateData()
	{
		DragResourceCapacity = CurrentLevelData.DragResourceCapacity;
		OnChange?.Invoke();
	}

	public void TakeResource()
	{
		if (someresources)
		{
			UpdateDragResource();
			someresources = false;
		}

		if (DragResourceCapacity > CurrentResources.IncomeResources.Resource) TakeSomeResource();
		else CurrentResources.IncomeResources.Resource -= DragResourceCapacity;

		OnChange?.Invoke();
		CurrentResources.Change();
	}

	public void PutResource()
	{
		CurrentResources.IncomeResources.Resource += DragResourceCapacity;
		OnChange?.Invoke();
		CurrentResources.Change();
	}
	
	public void TakeSomeResource()
	{
		DragResourceCapacity = CurrentResources.IncomeResources.Resource;
		CurrentResources.IncomeResources.Resource -= DragResourceCapacity;
		someresources = true;
	}

	public void PutSomeResources(int count)
	{
		CurrentResources.IncomeResources.Resource += count;
		OnChange?.Invoke();
		CurrentResources.Change();
	}

	public void UpdateDragResource()
	{
		DragResourceCapacity = CurrentResources.DragResourceValue();
	}
}
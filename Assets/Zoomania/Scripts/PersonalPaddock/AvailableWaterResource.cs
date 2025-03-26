using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableWaterResource : MonoBehaviour
{
	[field: SerializeField] private GameObject ResourceBuilding { get; set; }
	[field: SerializeField] private GameObject Resource { get; set; }
	public WaterBuildingValue WaterValue { get; set; }
	public WaterBuildingTimer WaterTimer { get; set; }
	public Resource_New Resource_New { get; private set; }
	private bool start { get; set; }
	private bool someresources { get; set; }


	public event Action OnChange;
	public event Action OnStart;

	public void Start()
	{
		start = false;
		someresources = false;

		WaterValue = ResourceBuilding.GetComponent<WaterBuildingValue>();
		WaterTimer = ResourceBuilding.GetComponent<WaterBuildingTimer>();
		WaterTimer.OnStart += Initialize;
	}

	private void Initialize()
	{
		Resource_New = Resource.GetComponent<Resource_New>();
		Resource_New.ChangeCapacity(WaterValue.CurrentLevelData().DragResourceCapacity);

		WaterValue.OnUpgrade += UpdateData;
		OnStart?.Invoke();
		OnChange?.Invoke();
	}

	public void UpdateDragResource()
	{
		if (someresources)
		{
			UpdateData();
			someresources = false;
		}

		if (Resource_New.GetCapacity() > WaterTimer.IncomeResources.Resource) TakeSomeResource();
		else TakeResource();

		OnChange?.Invoke();
		WaterTimer.Change();
	}

	private void UpdateData()
	{
		Resource_New.ChangeCapacity(WaterValue.DragResourceValue());
		OnChange?.Invoke();
	}

	public void TakeResource()
	{
		WaterTimer.IncomeResources.Resource -= Resource_New.GetCapacity();

		OnChange?.Invoke();
		WaterTimer.Change();
	}

	public void TakeSomeResource()
	{
		Resource_New.ChangeCapacity(WaterTimer.IncomeResources.Resource);
		WaterTimer.IncomeResources.Resource -= Resource_New.GetCapacity();
		someresources = true;
	}

	public void PutResource(float value)
	{
		WaterTimer.IncomeResources.Resource += value;
		OnChange?.Invoke();
		WaterTimer.Change();
	}
}

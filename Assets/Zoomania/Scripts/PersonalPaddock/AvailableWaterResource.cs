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
	public WaterResource Water { get; private set; }
	private bool start { get; set; }
	private bool someresources { get; set; }


	public event Action OnChange;
	public event Action OnStart;

	//public void Start()
	//{
	//	start = false;
	//	someresources = false;

	//	WaterValue = ResourceBuilding.GetComponent<WaterBuildingValue>();
	//	WaterTimer = ResourceBuilding.GetComponent<WaterBuildingTimer>();
	//	//WaterTimer.OnStart += Initialize;

	//	if (Input.touchSupported)
	//	{
	//		Initialize();
	//	}
	//	else if (Input.mousePresent)
	//	{
	//		WaterTimer.OnStart += Initialize;
	//	}
	//}

	//private void Initialize()
	//{
	//	Water = Resource.GetComponent<WaterResource>();
	//	Water.ChangeCapacity(WaterValue.CurrentLevelData().DragResourceCapacity);

	//	WaterValue.OnUpgrade += UpdateData;
	//	OnStart?.Invoke();
	//	OnChange?.Invoke();
	//}

	public void Initializing()
	{
		someresources = false;

		WaterValue = ResourceBuilding.GetComponent<WaterBuildingValue>();
		WaterTimer = ResourceBuilding.GetComponent<WaterBuildingTimer>();

		Water = Resource.GetComponent<WaterResource>();
		Water.ChangeCapacity(WaterValue.CurrentLevelData().DragResourceCapacity);

		WaterValue.OnUpgrade += UpdateData;
		OnChange?.Invoke();
	}

	public void UpdateDragResource()
	{
		if (someresources)
		{
			UpdateData();
			someresources = false;
		}

		if (Water.GetCapacity() > WaterTimer.IncomeResources.Resource) TakeSomeResource();
		else TakeResource();

		OnChange?.Invoke();
		WaterTimer.Change();
	}

	private void UpdateData()
	{
		Water.ChangeCapacity(WaterValue.DragResourceValue());
		OnChange?.Invoke();
	}

	public void TakeResource()
	{
		WaterTimer.IncomeResources.Resource -= Water.GetCapacity();

		OnChange?.Invoke();
		WaterTimer.Change();
	}

	public void TakeSomeResource()
	{
		Water.ChangeCapacity(WaterTimer.IncomeResources.Resource);
		WaterTimer.IncomeResources.Resource -= Water.GetCapacity();
		someresources = true;
	}

	public void PutResource(float value)
	{
		WaterTimer.IncomeResources.Resource += value;
		OnChange?.Invoke();
		WaterTimer.Change();
	}
}

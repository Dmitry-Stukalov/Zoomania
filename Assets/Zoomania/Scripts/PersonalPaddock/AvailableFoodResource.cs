using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableFoodResource : MonoBehaviour
{
	[field: SerializeField] private GameObject ResourceBuilding { get; set; }
	[field: SerializeField] private GameObject Resource { get; set; }
	public FoodBuildingValue FoodValue { get; set; }
	public FoodBuildingTimer FoodTimer { get; set; }
	public FoodResource Food { get; private set; }
	private bool start { get; set; }
	private bool someresources { get; set; }


	public event Action OnChange;
	public event Action OnStart;

	//public void Start()
	//{
	//	start = false;
	//	someresources = false;

	//	FoodValue = ResourceBuilding.GetComponent<FoodBuildingValue>();
	//	FoodTimer = ResourceBuilding.GetComponent<FoodBuildingTimer>();

	//	if (Input.touchSupported)
	//	{
	//		Initialize();
	//	}
	//	else if (Input.mousePresent)
	//	{
	//		FoodTimer.OnStart += Initialize;
	//	}
	//}

	//private void Initialize()
	//{
	//	Food = Resource.GetComponent<FoodResource>();

	//	FoodValue.OnUpgrade += UpdateData;
	//	OnStart?.Invoke();
	//	OnChange?.Invoke();
	//}

	public void Initializing()
	{
		someresources = false;

		FoodValue = ResourceBuilding.GetComponent<FoodBuildingValue>();
		FoodTimer = ResourceBuilding.GetComponent<FoodBuildingTimer>();

		Food = Resource.GetComponent<FoodResource>();
		FoodValue.OnUpgrade += UpdateData;

		OnChange?.Invoke();
	}

	public void UpdateDragResource()
	{
		if (someresources)
		{
			UpdateData();
			someresources = false;
		}

		if (Food.GetCapacity() > FoodTimer.IncomeResources.Resource) TakeSomeResource();
		else TakeResource();

		OnChange?.Invoke();
		FoodTimer.Change();
	}

	private void UpdateData()
	{
		Food.ChangeCapacity(FoodValue.DragResourceValue());
		OnChange?.Invoke();
	}

	public void TakeResource()
	{
		FoodTimer.IncomeResources.Resource -= Food.GetCapacity();

		OnChange?.Invoke();
		FoodTimer.Change();
	}

	public void TakeSomeResource()
	{
		Food.ChangeCapacity(FoodTimer.IncomeResources.Resource);
		FoodTimer.IncomeResources.Resource -= Food.GetCapacity();
		someresources = true;
	}

	public void PutResource(float value)
	{
		FoodTimer.IncomeResources.Resource += value;
		OnChange?.Invoke();
		FoodTimer.Change();
	}
}

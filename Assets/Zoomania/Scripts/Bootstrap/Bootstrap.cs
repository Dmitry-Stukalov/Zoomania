using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[field: SerializeField] private ObjectGallery Gallery;
	[field: SerializeField] private All_Objects AllObjects;
	[field: SerializeField] private Day_And_Night DayAndNight;
	[field: SerializeField] private TakeEssenceClick EssenceClick;
	[field: SerializeField] private TimeClick ClickTime;
	[field: SerializeField] private FoodBuildingTimer _FoodBuildingTimer;
	[field: SerializeField] private FoodBuildingValue _FoodBuildingValue;
	[field: SerializeField] private WaterBuildingTimer _WaterBuildingTimer;
	[field: SerializeField] private WaterBuildingValue _WaterBuildingValue;
	[field: SerializeField] private UIWaterResource WaterResource;
	[field: SerializeField] private UIFoodResource FoodResource;
	[field: SerializeField] private UIMoneyResource MoneyResource;
	[field: SerializeField] private UIEssenceResource EssenceResource;
	[field: SerializeField] private AvailableWaterResource _AvailableWaterResource;
	[field: SerializeField] private AvailableFoodResource _AvailableFoodResource;
	[field: SerializeField] private SpawnDragWaterResource _SpawnWaterResource;
	[field: SerializeField] private SpawnDragFoodResource _SpawnFoodResource;


	private void Start()
	{
		AllObjects.Initializing();
		Gallery.Initializing();
		DayAndNight.Initializing();
		EssenceClick.Initializing();
		ClickTime.Initializing();
		_WaterBuildingValue.Initializing();
		_FoodBuildingValue.Initializing();
		_WaterBuildingTimer.Initializing();
		_FoodBuildingTimer.Initializing();
		WaterResource.Initializing();
		FoodResource.Initializing();
		MoneyResource.Initializing();
		EssenceResource.Initializing();
		_AvailableWaterResource.Initializing();
		_AvailableFoodResource.Initializing();
		_SpawnWaterResource.Initializing();
		_SpawnFoodResource.Initializing();
	}
}

using System.Collections;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
	[SerializeField] private ObjectGallery Gallery;
	[SerializeField] private All_Objects AllObjects;
	[SerializeField] private Day_And_Night DayAndNight;
	[SerializeField] private TakeEssenceClick EssenceClick;
	[SerializeField] private TimeClick ClickTime;
	[SerializeField] private FoodBuildingTimer _FoodBuildingTimer;
	[SerializeField] private FoodBuildingValue _FoodBuildingValue;
	[SerializeField] private WaterBuildingTimer _WaterBuildingTimer;
	[SerializeField] private WaterBuildingValue _WaterBuildingValue;
	[SerializeField] private UIWaterResource WaterResource;
	[SerializeField] private UIFoodResource FoodResource;
	[SerializeField] private UIMoneyResource MoneyResource;
	[SerializeField] private UIEssenceResource EssenceResource;
	[SerializeField] private AvailableWaterResource _AvailableWaterResource;
	[SerializeField] private AvailableFoodResource _AvailableFoodResource;
	[SerializeField] private SpawnDragWaterResource _SpawnWaterResource;
	[SerializeField] private SpawnDragFoodResource _SpawnFoodResource;
	[SerializeField] private GameObject _loadObject;

	[Header("Improvements")]
	[SerializeField] private Bushes _bushes;
	[SerializeField] private Couch _couch;
	[SerializeField] private Grass _grass;
	[SerializeField] private Pond _pond;
	[SerializeField] private Slide _slide;
	[SerializeField] private Flashlights _flashlights;
	[SerializeField] private DeepSleep _deepSleep;
	[SerializeField] private EssenceQuality _essenceQuality;


	private void Start()
	{
		AllObjects.Initializing();
		DayAndNight.Initializing();
		EssenceClick.Initializing();
		ClickTime.Initializing();
		//_WaterBuildingValue.Initializing();
		//_FoodBuildingValue.Initializing();
		//_WaterBuildingTimer.Initializing();
		//_FoodBuildingTimer.Initializing();
		//WaterResource.Initializing();
		//FoodResource.Initializing();
		//MoneyResource.Initializing();
		//EssenceResource.Initializing();
		//_AvailableWaterResource.Initializing();
		//_AvailableFoodResource.Initializing();
		//_SpawnWaterResource.Initializing();
		//_SpawnFoodResource.Initializing();

		StartCoroutine(StartPause());
	}

	private IEnumerator StartPause()
	{
		yield return new WaitForSeconds(0.5f);

		_bushes.Initializing();
		_couch.Initializing();
		_grass.Initializing();
		_pond.Initializing();
		_slide.Initializing();
		_flashlights.Initializing();
		_deepSleep.Initializing();
		_essenceQuality.Initializing();
		Gallery.Initializing();
		_loadObject.SetActive(false);
	}
}

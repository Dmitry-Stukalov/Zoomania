using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoSaveAndLoad : MonoBehaviour
{
	[field: SerializeField] public TakeAllResources AllResoures;

	public void Awake()
	{
		SaveAndLoad.Load("DataSave", AllResoures.WaterBuildingV, AllResoures.WaterBuildingT, AllResoures.FoodBuildingV, AllResoures.FoodBuildingT, AllResoures.MoneyBuilding, AllResoures.EssenceBuilding, AllResoures.EssenceBuilding1, AllResoures.DeepSleepBuilding, AllResoures.Bamboo, AllResoures.Barn);
	}

	public void OnApplicationQuit()
	{
		SaveAndLoad.Save(AllResoures.TakeResoures(), AllResoures.TakeBuildingLevels(), AllResoures.TakeAnimals());
	}

	public void OnApplicationPause(bool pause)
	{
		if (pause == true) SaveAndLoad.Save(AllResoures.TakeResoures(), AllResoures.TakeBuildingLevels(), AllResoures.TakeAnimals());
	}
}
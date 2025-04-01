using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TakeAllResources : MonoBehaviour
{
	[field: SerializeField] public WaterBuildingValue WaterBuildingV;
	[field: SerializeField] public WaterBuildingTimer WaterBuildingT;
	[field: SerializeField] public FoodBuildingValue FoodBuildingV;
	[field: SerializeField] public FoodBuildingTimer FoodBuildingT;
	[field: SerializeField] public Money MoneyBuilding;
	[field: SerializeField] public Essence_Storage EssenceBuilding;
	[field: SerializeField] public Essence_Quality EssenceBuilding1;
	[field: SerializeField] public Deep_Sleep DeepSleepBuilding;
	[field: SerializeField] public Buy_Bamboo Bamboo;
	[field: SerializeField] public Barn Barn;
	[field: SerializeField] public Day_And_Night Time;

	private List<float> resources = new List<float>();
	private List<int> buildingLevels = new List<int>();
	private SaveDataClass.TimeData time;
	private List<GameObject> barnlist = new List<GameObject>();
	private List<SaveDataClass.AnimalData> animals = new List<SaveDataClass.AnimalData>();

	public IReadOnlyList<float> TakeResoures()
	{
		resources.Add(WaterBuildingT.GetResources());
		resources.Add(FoodBuildingT.GetResources());
		resources.Add(MoneyBuilding.GetMoney());
		resources.Add(EssenceBuilding.GetEssenceCount());


		IReadOnlyList<float> newList = resources;
		return newList;
	}

	public IReadOnlyList<int> TakeBuildingLevels()
	{
		buildingLevels.Add(WaterBuildingV.CurrentLevelData().CurrentLevelNumber);
		buildingLevels.Add(WaterBuildingT.CurrentLevelData().CurrentLevelNumber);
		buildingLevels.Add(FoodBuildingV.CurrentLevelData().CurrentLevelNumber);
		buildingLevels.Add(FoodBuildingT.CurrentLevelData().CurrentLevelNumber);
		buildingLevels.Add(EssenceBuilding1.CurrentLevelData().CurrentLevelNumber);
		buildingLevels.Add(DeepSleepBuilding.CurrentLevelData().CurrentLevelNumber);
		buildingLevels.Add(Bamboo.CurrentLevelData().CurrentLevelNumber);

		IReadOnlyList<int> newList = buildingLevels;
		return newList;
	}

	public SaveDataClass.TimeData TakeTime()
	{
		time = new SaveDataClass.TimeData(Time.IsDay, Time.GetCurrentTime());

		SaveDataClass.TimeData newtime = time;
		return newtime;
	}

	public IReadOnlyList<SaveDataClass.AnimalData> TakeAnimals()
	{
		barnlist = Barn.Animals;

		foreach (var animal in barnlist)
		{
			animals.Add(new SaveDataClass.AnimalData(animal.GetComponent<Animals>().CurrentLevelData().Type, animal.GetComponent<Animals>().CurrentLevelData().CurrentLevelNumber, 
				animal.GetComponent<Animal_Feeding>().GetRequiredWater(), animal.GetComponent<Animal_Feeding>().GetRequiredFood(), animal.transform.position.x, animal.transform.position.y, animal.transform.position.z));
		}

		IReadOnlyList<SaveDataClass.AnimalData> newList = animals;
		return newList;
	}
}

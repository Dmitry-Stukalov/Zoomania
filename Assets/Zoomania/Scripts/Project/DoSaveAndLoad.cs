using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoSaveAndLoad : MonoBehaviour
{
	[field: SerializeField] public TakeAllResources AllResoures;
	[field: SerializeField] public CleanSaveFile CleanFile;
	[field: SerializeField] public Panda_To_Common_Paddock PandaReturn;
	[field: SerializeField] private TutorialsObject Tutorial;
	private string DirectoryPath;
	private PointerEventData pointerdata;

	private void Awake()
	{
		if (Input.touchSupported)
		{
			DirectoryPath = Application.persistentDataPath + "/Source/MissionsSaves";
		}
		else if (Input.mousePresent)
		{
			DirectoryPath = Application.dataPath + "/Source/MissionsSaves";
		}

		SaveAndLoad.Load(DirectoryPath, "DataSave", AllResoures.WaterBuildingV, AllResoures.WaterBuildingT, AllResoures.FoodBuildingV, AllResoures.FoodBuildingT, AllResoures.MoneyBuilding, 
			AllResoures.EssenceBuilding, AllResoures.EssenceBuilding1, AllResoures.DeepSleepBuilding, AllResoures.Bamboo, AllResoures.Barn, AllResoures.Time, Tutorial);
	}

	public void OnApplicationQuit()
	{
		if (!CleanFile.DontSave)
		{
			PandaReturn.OnPointerClick(pointerdata);
			SaveAndLoad.Save(DirectoryPath, AllResoures.TakeResoures(), AllResoures.TakeBuildingLevels(), AllResoures.TakeAnimals(), AllResoures.TakeTime());
		}
	}

	public void OnApplicationPause(bool pause)
	{
		if (Input.touchSupported && !CleanFile.DontSave)
		{
			if (pause == true)
			{
				PandaReturn.OnPointerClick(pointerdata);
				SaveAndLoad.Save(DirectoryPath, AllResoures.TakeResoures(), AllResoures.TakeBuildingLevels(), AllResoures.TakeAnimals(), AllResoures.TakeTime());
			}
		}
	}
}
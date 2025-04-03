using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SaveAndLoad
{
	public static void Save(string directoryPath, IReadOnlyList<float> allResources, IReadOnlyList<int> allBuildingLevels, IReadOnlyList<SaveDataClass.AnimalData> allAnimals, SaveDataClass.TimeData allTime)
	{
		var DataSave = new SaveDataClass();
		DataSave.SetResoures(allResources);
		DataSave.SetBuildingLevels(allBuildingLevels);
		DataSave.SetTime(allTime);
		DataSave.SetAnimals(allAnimals);

		var json = JsonUtility.ToJson(DataSave);

		var DirectoryPath = directoryPath;
		const string fileName = "DataSave";

		if (!Directory.Exists(DirectoryPath))
			Directory.CreateDirectory(DirectoryPath);

		File.WriteAllText($"{DirectoryPath}/{fileName}.json", json);
	}


	public static async Task Load(/*CancellationToken cancelToken, */string directoryPath, string fileName, WaterBuildingValue waterBuildingV, WaterBuildingTimer waterBuildingT, FoodBuildingValue foodBuildingV, FoodBuildingTimer foodBuildingT, Money moneyBuilding, 
		Essence_Storage essenceBuilding, Essence_Quality essenceBuilding1, Deep_Sleep deepSleepBuilding, Buy_Bamboo bamboo, Barn barn, Day_And_Night time)
	{
		var DirectoryPath = directoryPath;
		if (!Directory.Exists(DirectoryPath))
		{
			Directory.CreateDirectory(DirectoryPath);
			Debug.LogError($"Cant find directory, so file doesnt exist: {DirectoryPath}");
			return;
		}

		if (!fileName.Contains(".json"))
			fileName += ".json";

		if (!File.Exists($"{DirectoryPath}/{fileName}"))
		{
			Debug.LogError($"File doesnt exist: {DirectoryPath}/{fileName}");
			return;
		}

		var json = await File.ReadAllTextAsync($"{DirectoryPath}/{fileName}"/*, cancelToken*/);
		/*if (cancelToken.IsCancellationRequested)
			cancelToken.ThrowIfCancellationRequested();*/

		var dataSave = JsonUtility.FromJson<SaveDataClass>(json);

		await waterBuildingV.LoadData(dataSave.Buildinglevels[0]);
		await waterBuildingT.LoadData(dataSave.Resources[0], dataSave.Buildinglevels[1]);
		await foodBuildingV.LoadData(dataSave.Buildinglevels[2]);
		await foodBuildingT.LoadData(dataSave.Resources[1], dataSave.Buildinglevels[3]);
		await moneyBuilding.LoadData(dataSave.Resources[2]);
		await essenceBuilding.LoadData(dataSave.Resources[3]);
		await essenceBuilding1.LoadData(dataSave.Buildinglevels[4]);
		await deepSleepBuilding.LoadData(dataSave.Buildinglevels[5]);
		await bamboo.LoadData(dataSave.Buildinglevels[6]);
		await barn.LoadData(dataSave.Animals);
		await time.LoadData(dataSave.Time);
	}

}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class CleanSaveFile : MonoBehaviour, IPointerClickHandler
{
	//public static readonly string DirectoryPath = Application.persistentDataPath + "/Source/MissionsSaves";
	//public static readonly string DirectoryPath = Application.dataPath + "/Source/MissionsSaves";
	public static string DirectoryPath;
	const string fileName = "DataSave";
	public bool DontSave = false;
	private void Start()
	{
		if (SystemInfo.deviceType == DeviceType.Handheld)
		{
			DirectoryPath = Application.persistentDataPath + "/Source/MissionsSaves";
		}
		else DirectoryPath = Application.dataPath + "/Source/MissionsSaves";
	}
	public void OnPointerClick(PointerEventData eventData)
	{
		DontSave = true;
		File.WriteAllText($"{DirectoryPath}/{fileName}.json", "");
	}
}

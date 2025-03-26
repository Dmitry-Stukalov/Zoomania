using Animal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(BuildingNamesList), menuName = "Buildings/" + nameof(BuildingNamesList))]
public class BuildingNamesList : ScriptableObject
{
	[field: SerializeField] public List<string> BuildingNames;
}

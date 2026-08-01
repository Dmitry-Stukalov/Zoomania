using Animal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(BuildingLevelsConfig), menuName = "Buildings/Levels/" + nameof(BuildingLevelsConfig))]
public class BuildingLevelsConfig : ScriptableObject
{
	[field: SerializeField] public List<BuildingLevel> levels;
}

using Animal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(Building_Levels_Config), menuName = "Buildings/Levels/" + nameof(Building_Levels_Config))]
public class Building_Levels_Config : ScriptableObject
{
	[field: SerializeField] public List<BuildingLevel> levels;
}

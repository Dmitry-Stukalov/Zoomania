using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(Improvement_Levels_Config_New), menuName = "Buildings/Levels/" + nameof(Improvement_Levels_Config_New))]
public class Improvement_Levels_Config_New : ScriptableObject
{
	[field: SerializeField] public List<Improvement_Level_New> levels;
}
using Animal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(Improvement_Levels_Config), menuName = "Buildings/Levels/" + nameof(Improvement_Levels_Config))]
public class Improvement_Levels_Config : ScriptableObject
{
	[field: SerializeField] public List<Improvement_Level_New> levels;
}

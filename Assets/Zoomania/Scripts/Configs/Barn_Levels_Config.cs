using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(Barn_Levels_Config), menuName = "Buildings/Levels/" + nameof(Barn_Levels_Config))]
public class Barn_Levels_Config : ScriptableObject
{
	[field: SerializeField] public List<Barn_Level> levels;
}

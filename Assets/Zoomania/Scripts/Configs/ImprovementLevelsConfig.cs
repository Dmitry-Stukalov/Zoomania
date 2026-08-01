using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(ImprovementLevelsConfig), menuName = "Buildings/Levels/" + nameof(ImprovementLevelsConfig))]
public class ImprovementLevelsConfig : ScriptableObject
{
	[field: SerializeField] public List<ImprovementLevel> levels;
}
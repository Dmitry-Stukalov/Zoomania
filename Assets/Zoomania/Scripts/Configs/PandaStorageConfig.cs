using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(PandaStorageConfig), menuName = "Animals/Storage/" + nameof(PandaStorageConfig))]
public class PandaStorageConfig : ScriptableObject
{
	[field: SerializeField] public List<GameObject> Animals;
}
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = nameof(Panda_Storage_Config), menuName = "Animals/Storage/" + nameof(Panda_Storage_Config))]
public class Panda_Storage_Config : ScriptableObject
{
	[field: SerializeField] public List<GameObject> Animals;
}
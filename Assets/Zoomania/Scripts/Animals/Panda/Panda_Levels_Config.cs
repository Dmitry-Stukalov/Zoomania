using Animal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animal
{
    [CreateAssetMenu(fileName = nameof(Panda_Levels_Config), menuName = "Animals/Panda" + nameof(Panda_Levels_Config))]
    public class Panda_Levels_Config : ScriptableObject
    {
        [field: SerializeField] public List<AnimalLevel> levels;

	}
}
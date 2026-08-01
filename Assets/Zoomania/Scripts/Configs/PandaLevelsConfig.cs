using Animal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animal
{
    [CreateAssetMenu(fileName = nameof(PandaLevelsConfig), menuName = "Animals/Panda" + nameof(PandaLevelsConfig))]
    public class PandaLevelsConfig : ScriptableObject
    {
        [field: SerializeField] public List<AnimalLevel> levels;
	}
}
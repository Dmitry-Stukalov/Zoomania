using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animal
{
    [CreateAssetMenu(fileName = nameof(Panda_Level_2_Config), menuName = "Animals/Panda" + nameof(Panda_Level_2_Config))]
    public class Panda_Level_2_Config : ScriptableObject
    {
		[field: SerializeField] public Sprite View { get; set; }
		[field: SerializeField] public int RequiredWater { get; set; }
        [field: SerializeField] public int RequiredFood { get; set; }
        [field: SerializeField] public int MoneyPerClick { get; set; }
        [field: SerializeField] public int MoneyPerSecond { get; set; }
        [field: SerializeField] public int WaterForUpgrade { get; set; }
        [field: SerializeField] public int FoodForUpgrade { get; set; }
		[field: SerializeField] public int UpgradeTime { get; set; }
	}
}

using Animal;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


namespace Animal
{
	public class AnimalLevel
	{
		public int CurrentLevelNumber { get; set; }

		public Sprite View { get; set; }
		public int RequiredWater { get; set; }
		public int RequiredFood { get; set; }
		public int MoneyPerClick { get; set; }
		public int MoneyPerSecond { get; set; }
		public int WaterForUpgrade { get; set; }
		public int FoodForUpgrade { get; set; }
		public int UpgradeTime { get; set; }


		public AnimalLevel(int levelnumber, Sprite view, int requiredwater, int requiredfood, int moneyperclick, int moneypersecond, int waterforupgrade, int foodforupgrade, int upgradetime)
		{
			CurrentLevelNumber = levelnumber;
			View = view;
			RequiredWater = requiredwater;
			RequiredFood = requiredfood;
			MoneyPerClick = moneyperclick;
			MoneyPerSecond = moneypersecond;
			WaterForUpgrade = waterforupgrade;
			FoodForUpgrade = foodforupgrade;
			UpgradeTime = upgradetime;
		}
	}
}

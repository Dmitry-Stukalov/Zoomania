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


		public AnimalLevel(int levelnumber, Sprite view, int requiredwater, int requiredfood, int moneyperclick, int moneypersecond, int waterforupgrade, int foodforupgrade)
		{
			CurrentLevelNumber = levelnumber;
			View = view;
			RequiredWater = requiredwater;
			RequiredFood = requiredfood;
			MoneyPerClick = moneyperclick;
			MoneyPerSecond = moneypersecond;
			WaterForUpgrade = waterforupgrade;
			FoodForUpgrade = foodforupgrade;
		}

		/*public void Upgrade()
		{
			if (CurrentLevelNumber == 4) return;

			CurrentLevelNumber++;
			RequiredWater += 4;
			RequiredFood += 4;
			MoneyPerClick += 2;
			MoneyPerSecond += 1;
			WaterForUpgrade *= 2;
			FoodForUpgrade *= 2;
		}*/
	}
}

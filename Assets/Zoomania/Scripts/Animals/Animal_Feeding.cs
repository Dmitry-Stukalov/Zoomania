using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Feeding : MonoBehaviour
{
	[field: SerializeField] private ProgressBar Bar { get; set; }
	private Animals_New Animal { get; set; }
	private bool IsEat { get; set; } = false;
	private bool IsDrinking { get; set; } = false;
	private int RequiredWater { get; set; }
	private int RequiredFood { get; set; }
	private int ReturnedResource { get; set; }

	public void Start()
	{
		Bar = gameObject.GetComponentInChildren<ProgressBar>().GetComponent<ProgressBar>();
		Animal = this.gameObject.GetComponent<Animals_New>();
		RequiredWater = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredWater;
		RequiredFood = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredFood;
		ChangeVisibility();
	}

	public int Drinking(int drinkvalue)
	{
		if (Animal.CurrentLevel.CurrentLevelNumber == 4) return drinkvalue;

		if (!IsDrinking)
		{
			if (drinkvalue - RequiredWater <= 0) ReturnedResource = 0;
			else ReturnedResource = drinkvalue - RequiredWater;

			RequiredWater -= drinkvalue;
			if (RequiredWater <= 0) IsDrinking = true;
			Bar.BarUpdate();
			
			CheckSatiety();

			return ReturnedResource;
		}

		return drinkvalue;
	}

	public int Eating(int foodvalue)
	{
		if (Animal.CurrentLevel.CurrentLevelNumber == 4) return foodvalue;

		if (!IsEat)
		{
			if (foodvalue - RequiredFood <= 0) ReturnedResource = 0;
			else ReturnedResource = foodvalue - RequiredFood;

			RequiredFood -= foodvalue;
			if (RequiredFood <= 0) IsEat = true;
			Bar.BarUpdate();

			CheckSatiety();

			return ReturnedResource;
		}

		return foodvalue;
	}

	public void CheckSatiety()
	{
		if (IsEat && IsDrinking)
		{
			IsDrinking = false;
			IsEat = false;
			Animal.Upgrade();
			RequiredWater = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredWater;
			RequiredFood = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredFood;
			Bar.BarUpgrade();
		}

		if (Animal.CurrentLevel.CurrentLevelNumber == 4)
		{
			Debug.Log("Панда больше не вырастет");
			Bar.GrownUp();
			return;
		}
	}

	public int GetRequiredResources()
	{
		return RequiredFood + RequiredWater;
	}

	public void ChangeVisibility()
	{
		Bar.SetSpriteRender();
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Animal_Feeding : MonoBehaviour
{
	[field: SerializeField] private Animals Animal { get; set; }
	[SerializeField] private GameObject Water;
	[SerializeField] private GameObject Food;
	private TextMeshPro WaterText { get; set; }
	private TextMeshPro FoodText { get; set; }
	private float RequiredWater { get; set; }
	private float RequiredFood { get; set; }
	private float ReturnedResource { get; set; }
	private bool IsEat { get; set; } = false;
	private bool IsDrinking { get; set; } = false;
	private bool IsLoadData { get; set; } = false;

	private void Start()
	{
		Animal = gameObject.GetComponent<Animals>();

		if (!IsLoadData)
		{
			RequiredWater = Animal.CurrentLevel.RequiredWater;
			RequiredFood = Animal.CurrentLevel.RequiredFood;
		}

        WaterText = Water.GetComponentInChildren<TextMeshPro>();
        FoodText = Food.GetComponentInChildren<TextMeshPro>();

        WaterText.text = RequiredWater.ToString();
		FoodText.text = RequiredFood.ToString();

		ChangeVisibility();
	}

	public float Drinking(float drinkvalue)
	{
		if (Animal.CurrentLevel.CurrentLevelNumber == 4) return drinkvalue;

		if (!IsDrinking)
		{
			if (drinkvalue - RequiredWater <= 0) ReturnedResource = 0;
			else ReturnedResource = drinkvalue - RequiredWater;

			RequiredWater -= drinkvalue;
			if (RequiredWater <= 0)
			{
				IsDrinking = true;
				RequiredWater = 0;
			}
			WaterText.text = RequiredWater.ToString();

			CheckSatiety();

			return ReturnedResource;
		}

		return drinkvalue;
	}

	public float Eating(float foodvalue)
	{
		if (Animal.CurrentLevel.CurrentLevelNumber == 4) return foodvalue;

		if (!IsEat)
		{
			if (foodvalue - RequiredFood <= 0) ReturnedResource = 0;
			else ReturnedResource = foodvalue - RequiredFood;

			RequiredFood -= foodvalue;
			if (RequiredFood <= 0)
			{
				IsEat = true;
				RequiredFood = 0;
			}
			FoodText.text = RequiredFood.ToString();

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
			RequiredWater = Animal.CurrentLevel.RequiredWater;
			RequiredFood = Animal.CurrentLevel.RequiredFood;
			WaterText.text = RequiredWater.ToString();
			FoodText.text = RequiredFood.ToString();

			Water.transform.position = new Vector2(Water.transform.position.x, Water.transform.position.y - 0.15f);
			Food.transform.position = new Vector2(Food.transform.position.x, Food.transform.position.y - 0.15f);
		}

		if (Animal.CurrentLevelData().CurrentLevelNumber == 4)
		{
			Water.SetActive(false);
			Food.SetActive(false);
			return;
		}
	}

	public float GetRequiredResources()
	{
		return RequiredFood + RequiredWater;
	}

	public float GetRequiredWater()
	{
		return RequiredWater;
	}

	public float GetRequiredFood()
	{
		return RequiredFood;
	}

	public void ChangeVisibility()
	{
		if (Animal.CurrentLevelData().CurrentLevelNumber < 4)
		{
			if (Water.activeSelf)
			{
				Water.SetActive(false);
				Food.SetActive(false);
			}
			else
			{
				Water.SetActive(true);
				Food.SetActive(true);
			}
		}

	}

	public void LoadData(float water, float food)
	{
		IsLoadData = true;

		RequiredWater = water;
		RequiredFood = food;

		if (RequiredWater == 0 && RequiredFood == 0) CheckSatiety();
	}
}

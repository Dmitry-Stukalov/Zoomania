using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Animal_Feeding : MonoBehaviour
{
	[SerializeField] private Animals Animal;
	[SerializeField] private GameObject Water;
	[SerializeField] private GameObject Food;
	private TextMeshPro WaterText;
	private TextMeshPro FoodText;
	private float RequiredWater;
	private float RequiredFood;
	private int _requiredFoodSubstractCoef;
	private int _requiredWaterSubstractCoef;
	private float ReturnedResource;
	private bool IsEat = false;
	private bool IsDrinking = false;
	private bool IsLoadData = false;

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

		GameEvents.OnRequiredFoodSubstract += (int value) =>
		{
			_requiredFoodSubstractCoef = value;
			CheckSatiety();
		};

		GameEvents.OnRequiredWaterSubstract += (int value) =>
		{
			_requiredWaterSubstractCoef = value;
			CheckSatiety();
		};

		CheckSatiety();
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
		if (RequiredFood == Animal.CurrentLevel.RequiredFood)
		{
			RequiredFood = Animal.CurrentLevel.RequiredFood - (Animal.CurrentLevel.RequiredFood * _requiredFoodSubstractCoef / 100);
			FoodText.text = RequiredFood.ToString();
		}

		if (RequiredWater == Animal.CurrentLevel.RequiredWater)
		{
			RequiredWater = Animal.CurrentLevel.RequiredWater - (Animal.CurrentLevel.RequiredWater * _requiredWaterSubstractCoef / 100);
			WaterText.text = RequiredWater.ToString();
		}

		if (IsEat && IsDrinking)
		{
			IsDrinking = false;
			IsEat = false;
			Animal.Upgrade();
			RequiredWater = Animal.CurrentLevel.RequiredWater - (Animal.CurrentLevel.RequiredWater * _requiredWaterSubstractCoef / 100);
			RequiredFood = Animal.CurrentLevel.RequiredFood - (Animal.CurrentLevel.RequiredFood * _requiredFoodSubstractCoef / 100);
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

	private void OnDisable()
	{
		GameEvents.OnRequiredFoodSubstract -= (int value) =>
		{
			_requiredFoodSubstractCoef = value;
			Debug.Log(_requiredFoodSubstractCoef);
			CheckSatiety();
		};

		GameEvents.OnRequiredWaterSubstract -= (int value) =>
		{
			_requiredWaterSubstractCoef = value;
			CheckSatiety();
		};
	}
}

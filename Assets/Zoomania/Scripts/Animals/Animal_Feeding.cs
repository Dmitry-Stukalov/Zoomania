using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Animal_Feeding : MonoBehaviour
{
	[field: SerializeField] private GameObject Water { get; set; }
	[field: SerializeField] private GameObject Food { get; set; }
	private TextMeshPro WaterText { get; set; }
	private TextMeshPro FoodText { get; set; }
	private Animals_New Animal { get; set; }
	private bool IsEat { get; set; } = false;
	private bool IsDrinking { get; set; } = false;
	private int RequiredWater { get; set; }
	private int RequiredFood { get; set; }
	private int ReturnedResource { get; set; }

	public void Start()
	{
		Animal = this.gameObject.GetComponent<Animals_New>();
		RequiredWater = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredWater;
		RequiredFood = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredFood;

		WaterText = Water.GetComponentInChildren<TextMeshPro>();
		FoodText = Food.GetComponentInChildren<TextMeshPro>();

		WaterText.text = RequiredWater.ToString();
		FoodText.text = RequiredFood.ToString();

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

	public int Eating(int foodvalue)
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
			RequiredWater = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredWater;
			RequiredFood = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredFood;
			WaterText.text = RequiredWater.ToString();
			FoodText.text = RequiredFood.ToString();

			Water.transform.position = new Vector2(Water.transform.position.x, Water.transform.position.y - 0.15f);
			Food.transform.position = new Vector2(Food.transform.position.x, Food.transform.position.y - 0.15f);
		}

		if (Animal.CurrentLevel.CurrentLevelNumber == 4)
		{
			Debug.Log("Панда больше не вырастет");
			Destroy(Water.gameObject);
			Destroy(Food.gameObject);
			return;
		}
	}

	public int GetRequiredResources()
	{
		return RequiredFood + RequiredWater;
	}

	public void ChangeVisibility()
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

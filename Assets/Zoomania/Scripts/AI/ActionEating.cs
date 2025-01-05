using Animal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEating
{
	private Animals Animal { get; set; }
	private ResourceBuilding foodbuilding { get; set; }
	private ResourceBuilding waterbuilding { get; set; }
	private MoneyPerClick moneyperclick { get; set; }

	public Timer EatingTime = new Timer(0);

	public bool IsEating = false;
	public bool IsDrinking = false;

	public ActionEating(Animals _Animal)
	{
		foodbuilding = GameObject.FindGameObjectWithTag("FoodBuilding").GetComponent<ResourceBuilding>();
		waterbuilding = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<ResourceBuilding>();
		moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();

		Animal = _Animal;
	}

	public void Eating(bool _Eating)
	{

		if (_Eating)
		{
			if (IsEating == true)
			{
				foodbuilding.SetData(Animal.GetComponent<Animals>().CurrentLevel.RequiredFood);

				if (Animal.Hungry == false && foodbuilding.GetData() == 0)
				{
					Animal.Hungry = true;
					moneyperclick.UpdateDataSpawn();
				}

				return;
			}

			Animal.Hungry = false;

			IsEating = true;

			moneyperclick.UpdateDataSpawn();

			EatingTime.SetMaxTimeAndReset(UnityEngine.Random.Range(3, 8));                      //Продолжительность этого действия

			Debug.Log("Панда ест");

			return;
		}
		else
		{
			if (IsDrinking == true)
			{
				waterbuilding.SetData(Animal.GetComponent<Animals>().CurrentLevel.RequiredWater);
				if (Animal.Hungry == false && waterbuilding.GetData() == 0)
				{
					Animal.Hungry = true;
					moneyperclick.UpdateDataSpawn();
				}

				return;
			}

			Animal.Hungry = false;

			IsDrinking = true;

			moneyperclick.UpdateDataSpawn();

			EatingTime.SetMaxTimeAndReset(UnityEngine.Random.Range(3, 8));                      //Продолжительность этого действия

			Debug.Log("Панда пьет");

			return;
		}
	}
}

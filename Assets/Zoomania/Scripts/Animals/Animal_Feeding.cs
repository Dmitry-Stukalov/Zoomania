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

	public void Start()
	{
		Bar = gameObject.GetComponentInChildren<ProgressBar>().GetComponent<ProgressBar>();
		Animal = this.gameObject.GetComponent<Animals_New>();
		RequiredWater = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredWater;
		RequiredFood = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredFood;
		ChangeVisibility();
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (Animal.CurrentLevel.CurrentLevelNumber == 4) return;
        
        if (collision.gameObject.tag == "Water" && Animal.CurrentLevel.CurrentLevelNumber < 4)
		{
			if (!IsDrinking)
			{

				Debug.Log("Пью");
				RequiredWater -= collision.gameObject.GetComponent<Resource_New>().GetCapacity();
				if (RequiredWater <= 0) IsDrinking = true;
				Bar.BarUpdate();
				Destroy(collision.gameObject);
			}
		}
		else if (collision.gameObject.tag == "Food")
		{
			if (!IsEat)
			{
				Debug.Log("Ем");
				RequiredFood -= collision.gameObject.GetComponent<Resource_New>().GetCapacity();
				if (RequiredFood <= 0) IsEat = true;
				Bar.BarUpdate();
				Destroy(collision.gameObject);
			}
		}

		if (IsEat && IsDrinking)
		{
			IsDrinking = false;
			IsEat = false;
			Animal.Upgrade();
			RequiredWater = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredWater;
			RequiredFood = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredFood;
			Bar.BarUpdate();
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

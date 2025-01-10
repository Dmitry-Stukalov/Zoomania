using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_Feeding : MonoBehaviour
{
	private Animals_New Animal { get; set; }
	private bool IsEat { get; set; } = false;
	private bool IsDrinking { get; set; } = false;
	private int RequiredWater { get; set; }
	private int RequiredFood { get; set; }

	public void Start()
	{
		Animal = this.gameObject.GetComponent<Animals_New>();
		RequiredWater = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredWater;
		RequiredFood = Animal.GetComponent<Animals_New>().CurrentLevel.RequiredFood;
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Water")
		{
			if (!IsDrinking)
			{

				Debug.Log("Ïüþ");
				RequiredWater -= collision.gameObject.GetComponent<Resource_New>().GetCapacity();
				if (RequiredWater <= 0) IsDrinking = true;
				Destroy(collision.gameObject);
			}
		}
		else if (collision.gameObject.tag == "Food")
		{
			if (!IsEat)
			{
				Debug.Log("Åì");
				RequiredFood -= collision.gameObject.GetComponent<Resource_New>().GetCapacity();
				if (RequiredFood <= 0) IsEat = true;
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
		}
	}
}

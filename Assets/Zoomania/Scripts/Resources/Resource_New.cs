using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_New : MonoBehaviour
{
	[field: SerializeField] private Sprite View { get; set; }
	private GameObject Animal { get; set; }
	private int Capacity { get; set; } = 0;
	private int ReturnedCapacity { get; set; } = 0;
	private bool OnAnimal { get; set; } = false;


	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Panda")
		{
			OnAnimal = true;
			Animal = collision.gameObject;
		}
	}

	public void OnCollisionExit2D(Collision2D collision)
	{
		OnAnimal = false;
		Animal = null;
	}

	public int TryFeedAnimal()
	{
		if (!OnAnimal) return Capacity;
		else
		{
			if (tag == "Water")
			{
				ReturnedCapacity = Animal.GetComponent<Animal_Feeding>().Drinking(Capacity);
			}

			if (tag == "Food")
			{
				ReturnedCapacity = Animal.GetComponent<Animal_Feeding>().Eating(Capacity);
			}
		}

		return ReturnedCapacity;
	}

	public void ChangeCapacity(int new_capacity)
	{
		Capacity = new_capacity;
	}

	public int GetCapacity()
	{
		return Capacity;
	}
}
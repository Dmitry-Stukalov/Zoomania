using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_New : MonoBehaviour
{
	[field: SerializeField] private Sprite View { get; set; }
	private GameObject Animal { get; set; }
	private int Capacity { get; set; } = 0;
	private int ReturnedCapacity { get; set; } = 0;
	private Vector3 Point { get; set; }
	private float Speed { get; set; }
	private bool IsMove { get; set; } = false;
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

	public void MoveToPoint(Vector3 point, float speed)
	{
		Point = point;
		Speed = speed;

		this.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
		IsMove = true;
	}

	public void Update()
	{
		if (IsMove)
		{
			this.gameObject.transform.position = Vector2.MoveTowards(this.transform.position, Point, Speed * Time.deltaTime);

			if (this.gameObject.transform.position.x == Point.x)
			{

				this.GetComponentInParent<Available_Resources>().PutResource(TryFeedAnimal());
				Destroy(this.gameObject);
			}
		}
	}
}
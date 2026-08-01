using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFoodResource : MonoBehaviour
{
	private Vector3 Point { get; set; }
	private float Speed { get; set; }
	private bool IsMove { get; set; } = false;


	public void Update()
	{
		if (IsMove)
		{
			gameObject.transform.position = Vector2.MoveTowards(transform.position, Point, Speed * Time.deltaTime);

			if (gameObject.transform.position.x == Point.x && gameObject.transform.position.y == Point.y)
			{

				//GetComponentInParent<AvailableFoodResource>().PutResource(GetComponent<FoodResource>().GetCapacity());
				Destroy(gameObject);
			}
		}
	}
}

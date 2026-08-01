using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterResource : MonoBehaviour
{
	/*[field: SerializeField] private Sprite View { get; set; }
	private GameObject Animal { get; set; }
	private float Capacity { get; set; } = 0;
	private float ReturnedCapacity { get; set; } = 0;
	private Vector2 Point { get; set; }
	private float Speed { get; set; }
	private Vector2 IntermediatePoint { get; set; }
	private Vector2 MotionVector { get; set; }
	private Vector2 ThisPoint { get; set; }
	private float DistanceLength { get; set; }
	private int PointCount { get; set; }
	private Vector2[] Points { get; set; }
	public bool IsMove { get; set; } = false;
	public bool IsMoving { get; set; } = false;
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

	public float TryFeedAnimal()
	{
		if (!OnAnimal) return Capacity;
		else
		{
			ReturnedCapacity = Animal.GetComponent<Animal_Feeding>().Drinking(Capacity);
		}

		return ReturnedCapacity;
	}

	public void ChangeCapacity(float new_capacity)
	{
		Capacity = new_capacity;
	}

	public float GetCapacity()
	{
		return Capacity;
	}

	public void FindAllPoints(Vector3 point, float speed)
	{
		Point = point;
		Speed = speed;

		ThisPoint = new Vector2(transform.position.x, transform.position.y);

		DistanceLength = Vector2.Distance(transform.position, Point);

		PointCount = UnityEngine.Random.Range(1, 4);
		Points = new Vector2[PointCount];

		MotionVector = Point - new Vector2(transform.position.x, transform.position.y);

		for (int i = 0; i < PointCount; i++)
		{
			float randomX = UnityEngine.Random.Range((MotionVector / PointCount * (i + 1) + ThisPoint).x - 2f, (MotionVector / PointCount * (i + 1) + ThisPoint).x + 2f);
			float randomY = UnityEngine.Random.Range((MotionVector / PointCount * (i + 1) + ThisPoint).y - 2f, (MotionVector / PointCount * (i + 1) + ThisPoint).y + 2f);

			Points[i] = new Vector2(randomX, randomY);
		}
		Points[Points.Length - 1] = new Vector2(point.x, point.y);
		PointCount = 0;
	}

	public Vector2 MoveToPoint(int pointnumber)
	{
		return Points[pointnumber];
	}

	public void Update()
	{
		if (IsMove)
		{
			if (!IsMoving)
			{
				IntermediatePoint = MoveToPoint(PointCount);
				IsMoving = true;
			}

			if (IsMoving)
			{
				transform.position = Vector2.MoveTowards(transform.position, IntermediatePoint, Speed * Time.deltaTime);

				if (Vector2.Distance(transform.position, IntermediatePoint) <= 0.01f)
				{
					PointCount++;
					if (PointCount == Points.Length)
					{
						GetComponentInParent<AvailableWaterResource>().PutResource(TryFeedAnimal());
						GetComponentInParent<SpawnDragWaterResource>().DestroyResource(gameObject);
					}
					IsMoving = false;
				}
			}
		}
	}*/
}

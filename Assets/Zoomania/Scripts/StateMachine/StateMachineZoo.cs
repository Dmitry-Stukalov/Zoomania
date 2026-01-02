using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachineZoo : StateMachineState
{
	private List<GameObject> MoveAreas;
	private List<Collider2D> Colliders;

	public StateMachineZoo(int id, StateMachineManager stateMachineManager, List<GameObject> moveAreas) : base(id, stateMachineManager)
	{
		MoveAreas = new List<GameObject>(moveAreas);

		Colliders = new List<Collider2D>();

		foreach (var area in MoveAreas)
		{
			var collider = area.GetComponent<Collider2D>();
			if (collider != null)
			{
				Colliders.Add(collider);
			}
		}
	}


	/*public void Walking(GameObject animal)                                                  //Двигает панду к рандомно сгенерированной точке
	{
		bool flag = false;

		flag = GetRandomPointWithinBounds(animal);

		if (!flag)
			while (!flag)
			{
				flag = GetRandomPointWithinBounds(animal);
			}

		WalkingTime.SetMaxTimeAndReset(Random.Range(7, 10));                      //Продолжительность этого действия
		Speed = Vector2.Distance(AnimalPosition, RandomPosition) / WalkingTime.MaxTime;
		IsMoving = true;
		flag = false;
		return;
	}

	public bool GetRandomPointWithinBounds(GameObject animal)                                //Задается рандомная точка в пределах объекта MoveArea
	{
		AnimalPosition = new Vector2(animal.transform.position.x, animal.transform.position.y);

		for (int i = 0; i < MoveAreas.Count; i++)
		{
			if (MoveAreas[i].GetComponent<Collider2D>().OverlapPoint(AnimalPosition))
			{
				CanMove = true;
				break;
			}
		}

		if (CanMove)
		{
			int pointcount = 4;


			RandomNumber = Random.Range(0, MoveAreas.Count);
			MoveArea = MoveAreas[RandomNumber];

			float randomX = UnityEngine.Random.Range(MoveArea.transform.position.x - MoveArea.transform.localScale.x / 2, MoveArea.transform.position.x + MoveArea.transform.localScale.x / 2);
			float randomY = UnityEngine.Random.Range(MoveArea.transform.position.y - MoveArea.transform.localScale.y / 2, MoveArea.transform.position.y + MoveArea.transform.localScale.y / 2);
			RandomPosition = new Vector2(randomX, randomY);


			AllDistance = Vector2.Distance(AnimalPosition, RandomPosition);

			for (float i = 1; i <= pointcount; i++)
			{
				float pointx = AnimalPosition.x + (i / (pointcount + 1)) * (RandomPosition.x - AnimalPosition.x);
				float pointy = AnimalPosition.y + (i / (pointcount + 1)) * (RandomPosition.y - AnimalPosition.y);
				RandomPosition2 = new Vector2(pointx, pointy);

				for (int j = 0; j < MoveAreas.Count; j++)
				{
					if (MoveAreas[j].GetComponent<Collider2D>().OverlapPoint(RandomPosition2))
					{
						Count++;
						break;
					}
				}
			}

			if (Count == pointcount)
			{
				Count = 0;
				return true;
			}
			else
			{
				Count = 0;
				return false;
			}
		}
		else
		{
			for (int i = 0; i < MoveAreas.Count; i++)
			{
				Vector2 AreaPosition = new Vector2(MoveAreas[i].transform.position.x, MoveAreas[i].transform.position.y);
				float mindistance = 1000;

				if (Vector2.Distance(AnimalPosition, AreaPosition) < mindistance)
				{
					mindistance = Vector2.Distance(AnimalPosition, AreaPosition);
					RandomPosition2 = AreaPosition;
					MoveArea = MoveAreas[i];
				}
			}

			float randomX = UnityEngine.Random.Range(MoveArea.transform.position.x - MoveArea.transform.localScale.x / 2, MoveArea.transform.position.x + MoveArea.transform.localScale.x / 2);
			float randomY = UnityEngine.Random.Range(MoveArea.transform.position.y - MoveArea.transform.localScale.y / 2, MoveArea.transform.position.y + MoveArea.transform.localScale.y / 2);

			RandomPosition2 = new Vector2(randomX, randomY);
			RandomPosition = RandomPosition2;
			return true;
		}
	}*/
}

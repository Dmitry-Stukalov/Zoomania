using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag_Resource : MonoBehaviour
{
	private Vector3 Point { get; set; }
	private float Speed { get; set; }
	private bool IsMove { get; set; } = false;


	public void MoveToPoint(Vector3 point, float speed)
	{
		Point = point;
		Speed = speed;

		Debug.Log(this.transform.position);
		Debug.Log(Point);

		IsMove = true;
	}

	public void Update()
	{
        if (IsMove)
        {
			this.gameObject.transform.position = Vector2.MoveTowards(this.transform.position, Point, Speed * Time.deltaTime);

			if (this.gameObject.transform.position.x == Point.x && this.gameObject.transform.position.y == Point.y) 
			{
				
				this.GetComponentInParent<Available_Resources>().PutResource(this.GetComponent<Resource_New>().GetCapacity());
				Destroy(this.gameObject);
			}
		}
	}
}

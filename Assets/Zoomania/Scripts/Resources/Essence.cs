using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Essence : MonoBehaviour
{
	private AnimalAI_New Panda { get; set; }
	private GameObject Money { get; set; }
	private bool IsMoving { get; set; }


	public void Start()
	{
		Panda = GetComponentInParent<AnimalAI_New>();
		Money = GameObject.FindGameObjectWithTag("Money");

		IsMoving = false;

		transform.SetParent(null);

		IsMoving = true;
	}

	public AnimalAI_New GetParent()
	{
		return Panda;
	}

	public void Update()
	{
		if (IsMoving)
		{
			transform.position = Vector3.MoveTowards(transform.position, Money.transform.position, 4f * Time.deltaTime);
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence_Storage : MonoBehaviour
{
	public int EssenceCount { get; set; }

	public event Action OnChange;

	public void Start()
	{
		EssenceCount = 0;
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Essence")
		{
			collision.gameObject.GetComponent<Essence>().GetParent().DestroyEssence(collision.gameObject);

			EssenceCount++;

			OnChange?.Invoke();
		}
	}

	public int GetEssenceCount()
	{
		return EssenceCount;
	}

	public void SoldOut()
	{
		EssenceCount = 0;
		OnChange?.Invoke();
	}
}
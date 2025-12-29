using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Essence_Storage : MonoBehaviour
{
	public float EssenceCount { get; set; } = 0;

	public event Action OnChange;

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Essence")
		{
			collision.gameObject.GetComponent<Essence>().GetParent().DestroyEssence(collision.gameObject);

			EssenceCount++;

			OnChange?.Invoke();
		}
	}

	public float GetEssenceCount()
	{
		return EssenceCount;
	}

	public async Task LoadData(float value)
	{
		EssenceCount = value;
		OnChange?.Invoke();
	}


	public void SoldOut()
	{
		EssenceCount = 0;
		OnChange?.Invoke();
	}
}
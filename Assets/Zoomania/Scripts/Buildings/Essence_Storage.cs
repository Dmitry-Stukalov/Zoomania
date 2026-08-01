using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Essence_Storage : MonoBehaviour, IResourceStorage
{
	//public float EssenceCount { get; set; } = 0;
	public ResourceType ResourceType { get; private set; }
	public IncomeResource IncomeResources { get; private set; }

	public event Action OnChange;

	private void Start()
	{
		IncomeResources = new IncomeResource(0, 0);
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Essence")
		{
			collision.gameObject.GetComponent<Essence>().GetParent().DestroyEssence(collision.gameObject);

			IncomeResources.CurrentResourceCount++;

			OnChange?.Invoke();
		}
	}

	public float GetEssenceCount()
	{
		return IncomeResources.CurrentResourceCount;
	}

	public async Task LoadData(float value)
	{
		IncomeResources.CurrentResourceCount = value;
		OnChange?.Invoke();
	}


	public void SoldOut()
	{
		IncomeResources.CurrentResourceCount = 0;
		OnChange?.Invoke();
	}
}
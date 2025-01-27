using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyCountBuffer : MonoBehaviour
{
	[field: SerializeField] private MoneyPerClick MoneyBuildingScript { get; set; }
	public int MoneyCount { get; set; }

	public event Action OnChange;


	public void Start()
	{
		MoneyCount = 0;

		MoneyBuildingScript.OnChange += UpdateData;
	}

	public void UpdateData()
	{
		MoneyCount = MoneyBuildingScript.IncomeMoney.Resource;
		OnChange?.Invoke();
	}

	public int GetMoneyCount()
	{
		return MoneyCount;
	}
}
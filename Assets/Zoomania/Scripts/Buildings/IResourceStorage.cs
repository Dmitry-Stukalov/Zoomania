using System;
using UnityEngine;

public interface IResourceStorage 
{
	public ResourceType ResourceType { get; }
	public IncomeResource IncomeResources { get; }

	public event Action OnChange;
}

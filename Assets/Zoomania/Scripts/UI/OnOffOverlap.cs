using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffOverlap : MonoBehaviour
{
	[field: SerializeField] private GameObject Overlap;

	private void Start()
	{
		ChangeOverlapActive();
	}

	public void ChangeOverlapActive()
	{
		if (Overlap.activeSelf) Overlap.SetActive(false);
		else Overlap.SetActive(true);
	}
}

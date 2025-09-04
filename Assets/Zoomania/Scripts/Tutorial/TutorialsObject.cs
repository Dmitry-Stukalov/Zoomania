using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Threading.Tasks;

public class TutorialsObject : MonoBehaviour
{
	[field: SerializeField] private Barn barn;
	private List<ContinueButton> ContinueBuittons = new List<ContinueButton>();
	private int ChildrenCount { get; set; } = 0;


	private void Start()
	{
		Time.timeScale = 0;
		ChildrenCount = transform.childCount;

		foreach (var button in GetComponentsInChildren<ContinueButton>())
		{
			ContinueBuittons.Add(button);
			button.OnDestroy += CheckObjects;
			if (ContinueBuittons.Count != ChildrenCount) button.BackgroundDeactivate();
		}
	}

	public async Task DestroyThis()
	{
		Destroy(gameObject);
	}

	private void CheckObjects()
	{
		if (transform.childCount == 1)
		{
			Time.timeScale = 1;
			Destroy(gameObject);
		}
	}
}

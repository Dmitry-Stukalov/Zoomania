using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
	[field:SerializeField] private GameObject BarBackground { get; set; }
	private Animal_Feeding AnimalFeeding { get; set; }
	private int MaxFeedValue { get; set; }
	private int CurrentFeedValue { get; set; }


	private float Value { get; set; }

	private void Start()
	{
		AnimalFeeding = gameObject.GetComponentInParent<Animal_Feeding>();

		this.transform.localScale = new Vector3(0, 0, 0);
		MaxFeedValue = AnimalFeeding.GetRequiredResources();

		Value = BarBackground.transform.localScale.x/MaxFeedValue;
	}

	public void BarUpdate()															//Увеличивает размер ProgressBar
	{
		CurrentFeedValue = MaxFeedValue - AnimalFeeding.GetRequiredResources();
		this.transform.localScale = new Vector3(BarBackground.transform.localScale.x/MaxFeedValue*CurrentFeedValue, BarBackground.transform.localScale.y, BarBackground.transform.localScale.z);
	}

	public void GrownUp()
	{
		BarBackground.SetActive(false);
		this.gameObject.SetActive(false);
	}

	public void SetSpriteRender()
	{
        if (this.gameObject.GetComponent<SpriteRenderer>().enabled == true)
		{
			BarBackground.GetComponent<SpriteRenderer>().enabled = false;
			this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
		else
		{
			BarBackground.GetComponent<SpriteRenderer>().enabled = true;
			this.gameObject.GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}

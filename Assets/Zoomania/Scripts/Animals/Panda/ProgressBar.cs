using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

	public Timer UpgradeTime { get; set; } = new Timer(10);
	[field:SerializeField] private GameObject BarBackground { get; set; }


	private float Value { get; set; }

	private void Start()
	{
		this.transform.localScale = new Vector3(0, 0, 0);
		Value = BarBackground.transform.localScale.x / UpgradeTime.MaxTime;
	}

	public void SetTimer(int value)													//Изменение максимального значения таймера
	{
		UpgradeTime.SetMaxTimeAndReset(value);
		Value = BarBackground.transform.localScale.x / UpgradeTime.MaxTime;
	}

	public void BarUpdate()															//Увеличивает размер ProgressBar
	{
		this.transform.localScale = new Vector3(UpgradeTime.CurrentTime * Value, BarBackground.transform.localScale.y, BarBackground.transform.localScale.z);
	}

}

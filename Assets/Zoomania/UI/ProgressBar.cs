using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

	public Timer UpgradeTime { get; set; } = new Timer(10);
	public SpriteRenderer Bar { get; set; }
	private float BarBackground { get; } = 5.442261f;

	private float Value { get; set; }

	private void Start()
	{
		Bar = gameObject.GetComponent<SpriteRenderer>();
		Bar.transform.localScale = new Vector3(0, 0.6613315f, 1.49736f);
		Value = BarBackground / UpgradeTime.MaxTime;
	}

	public void SetTimer(int value)
	{
		UpgradeTime.SetMaxTimeAndReset(value);
		Value = BarBackground / UpgradeTime.MaxTime;
	}

	public void BarUpdate()
	{
		Bar.transform.localScale = new Vector3(UpgradeTime.CurrentTime * Value, 0.6613315f, 1.49736f);
	}

}

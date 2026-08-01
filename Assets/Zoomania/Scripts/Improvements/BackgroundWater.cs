using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundWater : MonoBehaviour
{
	private Animator animator { get; set; }
	private int RandomNumber { get; set; }
	private bool IsOver { get; set; }
	private Timer PauseTime { get; set; }

	public void Start()
	{
		PauseTime = new Timer(10);

		IsOver = true;

		animator = GetComponent<Animator>();
	}

	public void RandomAnimation()
	{
		RandomNumber = Random.Range(1, 3);
		animator.SetBool(RandomNumber.ToString(), true);
	}

	public void Update()
	{
		if (IsOver)
		{
			PauseTime.Tick(Time.deltaTime);
		}

		if (IsOver && PauseTime.CurrentTime == PauseTime.MaxTime)
        {
			PauseTime.ResetTimer(false);
			IsOver = false;
			RandomAnimation();
        }
    }

	public void AnimationOver()
	{
		IsOver = true;
		animator.SetBool(RandomNumber.ToString(), false);
		PauseTime.Continue();
	}
}

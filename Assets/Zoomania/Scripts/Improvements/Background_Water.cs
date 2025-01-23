using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Water : MonoBehaviour
{
	private Animator animator { get; set; }
	private int RandomNumber { get; set; }
	private bool IsOver { get; set; } = true;
	private Timer PauseTime { get; set; } = new Timer(10);

	public void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void OnEnable()
	{
		animator = GetComponent<Animator>();
		animator.Rebind();
		animator.Update(0f);
		animator.Play("Water_Idle");
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

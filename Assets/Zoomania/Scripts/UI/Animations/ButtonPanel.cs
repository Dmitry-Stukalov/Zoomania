using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPanel : MonoBehaviour
{
	private Animator Animator { get; set; }


	private void Start()
	{
		Animator = GetComponent<Animator>();
	}

	public void OpenClose()
	{
		if (Animator.GetBool("IsOpen")) Animator.SetBool("IsOpen", false);
		else Animator.SetBool("IsOpen", true);
	}
}

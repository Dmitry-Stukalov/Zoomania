using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Resource : MonoBehaviour
{
	[field: SerializeField] private Animator animator { get; set; }

	public void SetAnimation()
	{
		if (animator.GetBool("IsOpen"))
		{
			animator.SetBool("IsOpen", false);
		}
		else animator.SetBool("IsOpen", true);

	}
}

using Animal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceIntoPersonalPaddock : MonoBehaviour
{
	[field: SerializeField] private GameObject AnimalPlace;

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Panda")
		{
			/*AnimalPlace = collision.gameObject;*/
			collision.gameObject.GetComponent<Animals>().ChangeParent(AnimalPlace);
			collision.gameObject.transform.parent = AnimalPlace.transform;
		}
	}
}

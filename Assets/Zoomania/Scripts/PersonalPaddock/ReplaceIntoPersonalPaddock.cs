using Animal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceIntoPersonalPaddock : MonoBehaviour
{
	[field: SerializeField] private GameObject AnimalPlace;

	public void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Panda" && AnimalPlace.transform.childCount == 0)
		{
			collision.gameObject.GetComponent<Animals>().ChangeParent(AnimalPlace, true);
			collision.gameObject.transform.parent = AnimalPlace.transform;
			collision.gameObject.transform.localScale *= 7;
			collision.gameObject.transform.position = AnimalPlace.transform.position;
			collision.gameObject.GetComponent<AnimalAI_New>().PersonalPaddock();
			collision.gameObject.GetComponent<ReplaceToPersonalPaddock>().InPersonalPaddock = true;
		}
		else Debug.Log("Личный загон занят");
	}
}

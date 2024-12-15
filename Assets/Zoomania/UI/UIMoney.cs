using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIMoney : MonoBehaviour
{
	public GameObject MoneyPerClick;
	public TextMeshProUGUI Text;
	public MoneyPerClick animalmoneyscript;

	public void Start()
	{
		MoneyPerClick = GameObject.FindGameObjectWithTag("Money");
		animalmoneyscript = MoneyPerClick.GetComponent<MoneyPerClick>();
		Text = this.gameObject.GetComponent<TextMeshProUGUI>();

		animalmoneyscript.OnChange += UpdateUI;
	}

	public void UpdateUI()
	{
		Text.text = $"{animalmoneyscript.IncomeMoney.Resource.GetValue()}";
	}
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Panda_Sale_Button : ShopUpgradeButtonBase
{
	[SerializeField] private GameObject Panel;
	private SalePandaPanelCreator PanelCreator;
	private Animals Animal;


	protected override void Start()
	{
		base.Start();

		UpdateData();
		Money.OnChange -= CheckMask;
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		Money.IncomeMoney.Resource += Animal.CurrentLevelData().MoneyForSale;
		Money.InvokeChanges();

		PanelCreator.DeletePanel(Panel);
	}

	public void ChangeAnimal(Animals animal) => Animal = animal;
	public Animals GetAnimal() => Animal;

	public void ChangeCreator(SalePandaPanelCreator creator) => PanelCreator = creator;
}

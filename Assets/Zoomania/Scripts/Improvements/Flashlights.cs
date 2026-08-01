using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

//Поменять эффект после покупки
public class Flashlights : ImprovementBase
{
	[SerializeField] private TakeEssenceClick _essenceClick;
	[SerializeField] private List<GameObject> _flashlights;

	protected override void AddImprovementEffect()
	{
		_improvement.AddEffect(new EnableObjectsEffect(_flashlights));
		_improvement.AddEffect(new ChangeTimeSkipEffect(_essenceClick, true));
	}
}
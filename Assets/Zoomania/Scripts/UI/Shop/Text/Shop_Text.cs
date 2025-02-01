using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shop_Text : MonoBehaviour
{
	[field: SerializeField] public GameObject Building { get; set; }
	private TextMeshProUGUI Text { get; set; }
	private MonoBehaviour Script { get; set; }
	private ResourceBuilding resourceBuilding { get; set; }
	private Barn Barn { get; set; }
	private HeadOfBarn Head { get; set; }
	private bool IsResourceBuilding { get; set; } = false;
	private bool IsBarn { get; set; } = false;
	private bool IsHead { get; set; } = false;

	public void Start()
	{
		Script = GetScript<ResourceBuilding, Barn, HeadOfBarn>(Building);

		Text = gameObject.GetComponent<TextMeshProUGUI>();

		if (IsResourceBuilding)
		{
			resourceBuilding = Script.GetComponent<ResourceBuilding>();
			UpdateData();
			resourceBuilding.OnLevelUp += UpdateData;
		}

		if (IsBarn)
		{
			Barn = Script.GetComponent<Barn>();
			UpdateData();
			Barn.OnLevelUp += UpdateData;
		}

		if (IsHead)
		{
			Head = Script.GetComponent<HeadOfBarn>();
			UpdateData();
			Head.OnUpgrade += UpdateData;
		}
	}

	public MonoBehaviour GetScript<T1, T2, T3>(GameObject Building) where T1 : ResourceBuilding where T2 : Barn where T3 : HeadOfBarn
	{
		if (Building.TryGetComponent<T1>(out T1 script1))
		{
			IsResourceBuilding = true;
			return script1;
		}
		else if (Building.TryGetComponent<T2>(out T2 script2))
		{
			IsBarn = true;
			return script2;
		}
		else if (Building.TryGetComponent<T3>(out T3 script3))
		{
			IsHead = true;
			return script3;
		}

		return null;
	}

	
	public void UpdateData()
	{
		if (IsResourceBuilding)
		{
			if (resourceBuilding.NextLevelData() == null)
			{
				Text.text = $"Уровень max: {resourceBuilding.CurrentLevel.CurrentLevelNumber}\n";

				Text.text += $"Доход max: {resourceBuilding.CurrentLevel.IncomePerSecondValue}\n";

				Text.text += $"Доход max: {resourceBuilding.CurrentLevel.IncomePerClickValue}\n";
			}
			else
			{
				Text.text = $"Уровень {resourceBuilding.CurrentLevel.CurrentLevelNumber} -> {resourceBuilding.NextLevelData().CurrentLevelNumber}\n";

				Text.text += $"Доход за время {resourceBuilding.CurrentLevel.IncomePerSecondValue} -> {resourceBuilding.NextLevelData().IncomePerSecondValue}\n";

				Text.text += $"Доход за клик {resourceBuilding.CurrentLevel.IncomePerClickValue} -> {resourceBuilding.NextLevelData().IncomePerClickValue}\n";
			}
		}

		if (IsBarn)
		{
			if (Barn.NextLevelData() == null)
			{
				Text.text = $"Уровень max: {Barn.CurrentLevel.CurrentLevelNumber}\n";

				Text.text += $"Клик max: {Barn.CurrentLevel.ClicksAtTime}\n";
			}
			else
			{
				Text.text = $"Уровень {Barn.CurrentLevel.CurrentLevelNumber} -> {Barn.NextLevelData().CurrentLevelNumber}\n";

				Text.text += $"Клик {Barn.CurrentLevel.ClicksAtTime} -> {Barn.NextLevelData().ClicksAtTime}\n";
			}
		}

		if (IsHead)
		{
			if (Head.NextLevelData() == null)
			{
				Text.text = $"Уровень max: {Head.CurrentLevel.CurrentLevelNumber}\n";

				Text.text += $"Автоклик max: {Head.CurrentLevel.EffectValue}\n";
			}
			else
			{
				Text.text = $"Уровень {Head.CurrentLevel.CurrentLevelNumber} -> {Head.NextLevelData().CurrentLevelNumber}\n";

				Text.text += $"Автоклик {Head.CurrentLevel.EffectValue} -> {Head.NextLevelData().EffectValue}\n";
			}
		}
	}
}

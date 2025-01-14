using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barn_Shop_Text : MonoBehaviour
{
	[field: SerializeField] private Barn Barn { get; set; }
	private Barn_Level LevelData { get; set; }
	private TextMeshProUGUI text { get; set; }

	public void Start()
	{
		LevelData = Barn.NextLevelData();

		text = gameObject.GetComponent<TextMeshProUGUI>();
		text.text = $"Уровень {Barn.CurrentLevel.CurrentLevelNumber} -> {LevelData.CurrentLevelNumber}\n";
		text.text += $"Клик {Barn.CurrentLevel.ClicksAtTime} -> {LevelData.ClicksAtTime}\n";

		Barn.OnLevelUp += UpdateData;
	}

	public void UpdateData()
	{
		LevelData = Barn.NextLevelData();

		if (LevelData == null )
		{
			text.text = $"Уровень max: {Barn.CurrentLevel.CurrentLevelNumber}\n";

			text.text += $"Клик max: {Barn.CurrentLevel.ClicksAtTime}\n";
		}
		else
		{
			text.text = $"Уровень {Barn.CurrentLevel.CurrentLevelNumber} -> {LevelData.CurrentLevelNumber}\n";

			text.text += $"Клик {Barn.CurrentLevel.ClicksAtTime} -> {LevelData.ClicksAtTime}\n";
		}
	}
}

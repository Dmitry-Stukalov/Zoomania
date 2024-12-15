using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFoodWaterBuilding
{
	public int ValuePerSecond { get; set; }
	public int ValuePerClick { get; set; }

	public int IncreasingValuePerSecond { get; set; }
	public int IncreasingValuePerClick { get; set; }


	public LevelFoodWaterBuilding(int valuepersecond, int valueperclick, int increasingvaluepersecond, int increasingvalueperclick)
	{
		ValuePerSecond = valuepersecond;
		ValuePerClick = valueperclick;
		IncreasingValuePerSecond = increasingvaluepersecond;
		IncreasingValuePerClick = increasingvalueperclick;
	}


	public void LevelUp()
	{
		ValuePerSecond *= IncreasingValuePerSecond;
		ValuePerClick *= IncreasingValuePerClick;
		Debug.Log("Уровень здания повышен!");
		Debug.Log($"Доход увеличен в секунду увеличен до {ValuePerSecond}. Доход при нажатии увеличен до {ValuePerClick}");
	}

	public int GetValuePerSecond()
	{
		return ValuePerSecond;
	}

	public int GetValuePerClick()
	{
		return ValuePerClick;
	}
}

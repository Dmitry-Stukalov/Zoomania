using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntStorage												//Класс для хранения значений типа int
{
	public int CurrentValue { get; set; }							//Хранимое значение

	public IntStorage() 
	{
		CurrentValue = 0;
	}

	public IntStorage(int value)
	{
		CurrentValue = value;
	}

	public void SetValue(int value, bool plus)										//Изменить значение
	{
		if (plus) CurrentValue += value;
		else
		{
			CurrentValue -= value;
			if (CurrentValue < 0) CurrentValue = 0;
		}
	}

	public void ChangeValue(int value)
	{
		CurrentValue = value;
	}

	public int GetValue()												//Получить значение
	{
		return CurrentValue;
	}
}

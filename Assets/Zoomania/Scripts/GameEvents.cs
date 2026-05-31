using System;

public static class GameEvents
{
	public static Action OnAnimalSpawn;
	public static Action<int, int> OnAlmanacUpdate;

	public static Action OnAutoClickOpen;

	public static Action<float> OnPandaEssenceMultiplyChange;

	public static Action<int> OnRequiredFoodSubstract;
	public static Action<int> OnRequiredWaterSubstract;
}

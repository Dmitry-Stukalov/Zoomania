using UnityEngine;

public class ChangeTimeSkipEffect : IImprovementEffect
{
	private IChangeTimeSkip _timeSkip;
	private bool IsPlus;

	public ChangeTimeSkipEffect(IChangeTimeSkip timeSkip, bool isPlus)
	{
		_timeSkip = timeSkip;
		IsPlus = isPlus;
	}

	public void ApplyUpgrade(ImprovementLevel newLevel)
	{
		_timeSkip.ChangeTimeSkip(newLevel.EffectValue, IsPlus);
	}
}

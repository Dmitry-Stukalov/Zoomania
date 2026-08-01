using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

//Общий класс для поилки и кормушки
public class ResourceBuilding : MonoBehaviour, IResourceBuilding, IUpgradable
{
	[SerializeField] private BuildingLevelsConfig _levelsConfig;
	[SerializeField] private ImprovementLevelsConfig _timeLevelsConfig;
	[SerializeField] private ParticleSystem Click;
	[SerializeField] private AudioSource Audio;
	public ResourceType ResourceType { get; private set; }
	public BuildingLevel CurrentLevel { get; private set; }
	public ImprovementLevel CurrentTimeLevel { get; private set; }
	public IncomeResource IncomeResources { get; private set; }
	private ResourceBuildingData _buildingData;

	private SpriteRenderer _spriteRenderer;

	public event Action OnChange;
	public event Action OnUpgrade;

	public void Initializing()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();

		CurrentLevel = _levelsConfig.levels[0];
		CurrentTimeLevel = _timeLevelsConfig.levels[0];
		ChangeCurrentSprite();

		IncomeResources = new IncomeResource(CurrentLevel.IncomePerSecondValue, CurrentTimeLevel.EffectValue);
		IncomeResources.ResourceTimer.OnTimerEnd += Effects;

		_buildingData = new ResourceBuildingData(_levelsConfig, _timeLevelsConfig, ResourceType, CurrentLevel, CurrentTimeLevel, IncomeResources);
	}

	public void OnEnable()
	{
		OnUpgrade += UpdateIncomeResourceData;
	}

	public void OnDisable()
	{
		OnUpgrade -= UpdateIncomeResourceData;
		IncomeResources.OnDisable();
	}

	private void Effects()
	{
		Click.Play();
		Audio.Play();

		OnChange?.Invoke();
	}

	public void AddResource(int value)
	{
		_buildingData.AddResource(value);

		OnChange?.Invoke();
	}

	public void Upgrade()
	{
		_buildingData.Upgrade();
		ChangeCurrentSprite();

		OnUpgrade?.Invoke();
	}

	public void UpgradeTime()
	{
		_buildingData.UpgradeTime();
		IncomeResources.ChangeTime(CurrentTimeLevel.EffectValue);

		OnUpgrade?.Invoke();
	}

	public void UpdateIncomeResourceData() => _buildingData.UpdateIncomeResourceData();

	public int GetLevelsCount() => _levelsConfig.levels.Count;
	public int GetTimerLevelsCount() => _timeLevelsConfig.levels.Count;

	private void ChangeCurrentSprite() => _spriteRenderer.sprite = CurrentLevel.View;

	private void Update() => IncomeResources?.Update(Time.deltaTime);
}

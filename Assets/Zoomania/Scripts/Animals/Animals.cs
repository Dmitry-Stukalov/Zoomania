using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

namespace Animal
{
    public class Animals : MonoBehaviour
    {
        public Panda_Levels_Config levels_config;

		public IncomeResource IncomeMoney { get; private set; }
        public AnimalLevel CurrentLevel { get; private set; }

		public GameObject WaterBuilding { get; private set; }

		public ResourceBuilding waterbuildingscript { get; private set; }

		public GameObject FoodBuilding { get; private set; }

		public ResourceBuilding foodbuildingscript { get; private set; }

		public MoneyPerClick moneyperclick { get; private set; }

		public ProgressBar Bar { get; private set; }

        public AudioSource SoundLevelUp;
        public AudioSource SoundSpawn;

		public event Action LevelUp;

        public bool Hungry { get; set; } = false;


        public void Start()
        {

            CurrentLevel = levels_config.levels[0];

            IncomeMoney = new IncomeResource(CurrentLevel.MoneyPerSecond, CurrentLevel.MoneyPerClick);

            WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding");
            waterbuildingscript = WaterBuilding.GetComponent<ResourceBuilding>();
            waterbuildingscript.OnChange += UpdateData;

            FoodBuilding = GameObject.FindGameObjectWithTag("FoodBuilding");
            foodbuildingscript = FoodBuilding.GetComponent<ResourceBuilding>();
            foodbuildingscript.OnChange += UpdateData;

            Bar = gameObject.GetComponentInChildren<ProgressBar>().GetComponent<ProgressBar>();

            Bar.SetTimer(CurrentLevel.UpgradeTime);
            Bar.UpgradeTime.OnTimerEnd += Upgrade;

            moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();
            IncomeMoney.ResourceTimer.OnTimerEnd += GetMoney;

			SoundSpawn.Play();
        }

		public void UpdateData()
        {
            waterbuildingscript = WaterBuilding.GetComponent<ResourceBuilding>();
            foodbuildingscript = FoodBuilding.GetComponent<ResourceBuilding>();
		}

        public void GetMoney()
        {
            if (Hungry) moneyperclick.UpdateDataPerSecond(1);
            else moneyperclick.UpdateDataPerSecond(IncomeMoney.IncomePerSecondValue);
        }

        public void Upgrade()
        {
            if (waterbuildingscript.GetData() < CurrentLevel.WaterForUpgrade || foodbuildingscript.GetData() < CurrentLevel.FoodForUpgrade)
            {
                Bar.UpgradeTime.ResetTimer(false);
                return;
            }

            waterbuildingscript.SetData(CurrentLevel.WaterForUpgrade);
            foodbuildingscript.SetData(CurrentLevel.FoodForUpgrade);

			CurrentLevel = levels_config.levels[CurrentLevel.CurrentLevelNumber];
			this.gameObject.GetComponent<SpriteRenderer>().sprite = CurrentLevel.View;

            IncomeMoney.IncomePerSecondValue = CurrentLevel.MoneyPerSecond;
            IncomeMoney.IncomePerClickValue = CurrentLevel.MoneyPerClick;

            Bar.UpgradeTime.ResetTimer(false);

			SoundLevelUp.Play();

            LevelUp?.Invoke();
        }

		void Update()
		{
            IncomeMoney.Update(Time.deltaTime);
            if (CurrentLevel.CurrentLevelNumber < 4 && waterbuildingscript.GetData() >= CurrentLevel.WaterForUpgrade && foodbuildingscript.GetData() >= CurrentLevel.FoodForUpgrade)
            {
                Bar.UpgradeTime.Tick(Time.deltaTime);
                Bar.BarUpdate();
            }
		}
	}
}
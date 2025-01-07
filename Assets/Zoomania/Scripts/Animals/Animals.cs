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
		public ResourceBuilding waterbuildingscript { get; private set; }
		public ResourceBuilding foodbuildingscript { get; private set; }
		public MoneyPerClick moneyperclick { get; private set; }
		public ProgressBar Bar { get; private set; }
        private GameObject Barn { get; set; }

        public AudioSource SoundLevelUp;
        public AudioSource SoundSpawn;

		public event Action LevelUp;

        private int TimerForGetMoney = 5;
        public bool Hungry { get; set; } = false;


        public void Start()
        {

            CurrentLevel = levels_config.levels[0];

            Barn = GameObject.FindGameObjectWithTag("Barn");

            ChangeParent(Barn);

            IncomeMoney = new IncomeResource(CurrentLevel.MoneyPerSecond, CurrentLevel.MoneyPerClick, TimerForGetMoney);

            waterbuildingscript = GameObject.FindGameObjectWithTag("WaterBuilding").GetComponent<ResourceBuilding>();

            foodbuildingscript = GameObject.FindGameObjectWithTag("FoodBuilding").GetComponent<ResourceBuilding>();

            Bar = gameObject.GetComponentInChildren<ProgressBar>().GetComponent<ProgressBar>();

            Bar.SetTimer(CurrentLevel.UpgradeTime);
            Bar.UpgradeTime.OnTimerEnd += Upgrade;

            moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();
            IncomeMoney.ResourceTimer.OnTimerEnd += GetMoney;

			SoundSpawn.Play();
        }

        public void GetMoney()                                                                  //Пассивное получение монет
        {
            if (Hungry) moneyperclick.UpdateDataPerSecond(1);
            else moneyperclick.UpdateDataPerSecond(IncomeMoney.IncomePerSecondValue);
        }

        public void Upgrade()                                                                   //Повышение уровня панды
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

        public void ChangeParent(GameObject newparent)
        {
            this.transform.parent = newparent.transform;

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
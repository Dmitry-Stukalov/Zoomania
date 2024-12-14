using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

namespace Animal
{
    public class Animals : MonoBehaviour
    {
        public Panda_Level_1_Config config1;
        public Panda_Level_2_Config config2;
        public Panda_Level_3_Config config3;
        public Panda_Level_4_Config config4;

        public List<AnimalLevel> levels = new List<AnimalLevel>();


		public IncomeResource IncomeMoney;
		public AnimalLevel CurrentLevel { get; private set; }

		public GameObject WaterBuilding;

		public WaterBuilding waterbuildingscript;

		public GameObject FoodBuilding;

		public FoodBuilding foodbuildingscript;

        public MoneyPerClick moneyperclick;
        
        public ProgressBar Bar;


		public event Action OnChange;
        public event Action LevelUp;

        public bool Hungry { get; set; } = false;


		public void Start()
        {
            InitializeLevels();

            CurrentLevel = levels[0];

            IncomeMoney = new IncomeResource(CurrentLevel.MoneyPerSecond, CurrentLevel.MoneyPerClick);

			WaterBuilding = GameObject.FindGameObjectWithTag("WaterBuilding");
			waterbuildingscript = WaterBuilding.GetComponent<WaterBuilding>();
			waterbuildingscript.OnChange += UpdateData;

			FoodBuilding = GameObject.FindGameObjectWithTag("FoodBuilding");
			foodbuildingscript = FoodBuilding.GetComponent<FoodBuilding>();
			foodbuildingscript.OnChange += UpdateData;

            Bar = gameObject.GetComponentInChildren<ProgressBar>().GetComponent<ProgressBar>();

            Bar.SetTimer(CurrentLevel.UpgradeTime);
            Bar.UpgradeTime.OnTimerEnd += Upgrade;

            moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();
			IncomeMoney.ResourceTimer.OnTimerEnd += GetMoney;
		}

		public void InitializeLevels()
        {
            levels.Add(new AnimalLevel(1, config1.View, config1.RequiredWater, config1.RequiredFood, config1.MoneyPerClick, config1.MoneyPerSecond, config1.WaterForUpgrade, config1.FoodForUpgrade, config1.UpgradeTime));
			levels.Add(new AnimalLevel(2, config2.View, config2.RequiredWater, config2.RequiredFood, config2.MoneyPerClick, config2.MoneyPerSecond, config2.WaterForUpgrade, config2.FoodForUpgrade, config2.UpgradeTime));
			levels.Add(new AnimalLevel(3, config3.View, config3.RequiredWater, config3.RequiredFood, config3.MoneyPerClick, config3.MoneyPerSecond, config3.WaterForUpgrade, config3.FoodForUpgrade, config3.UpgradeTime));
			levels.Add(new AnimalLevel(4, config4.View, config4.RequiredWater, config4.RequiredFood, config4.MoneyPerClick, config4.MoneyPerSecond, config4.WaterForUpgrade, config4.FoodForUpgrade, config4.UpgradeTime));
		}

		public void UpdateData()
        {
            waterbuildingscript = WaterBuilding.GetComponent<WaterBuilding>();
            foodbuildingscript = FoodBuilding.GetComponent<FoodBuilding>();
		}

        public void GetMoney()
        {
            if (/*(waterbuildingscript.GetData() < CurrentLevel.RequiredWater || foodbuildingscript.GetData() < CurrentLevel.RequiredFood)*/Hungry) moneyperclick.UpdateDataPerSecond(1);
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

            CurrentLevel = levels[CurrentLevel.CurrentLevelNumber];
            this.gameObject.GetComponent<SpriteRenderer>().sprite = CurrentLevel.View;

            IncomeMoney.IncomePerSecondValue = CurrentLevel.MoneyPerSecond;
            IncomeMoney.IncomePerClickValue = CurrentLevel.MoneyPerClick;

            Bar.UpgradeTime.ResetTimer(false);
            Debug.Log($"Данные моего нового уровня: {CurrentLevel.RequiredWater}, {CurrentLevel.RequiredFood}, {CurrentLevel.MoneyPerClick}, {CurrentLevel.MoneyPerSecond}, {CurrentLevel.WaterForUpgrade}, {CurrentLevel.FoodForUpgrade}");

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
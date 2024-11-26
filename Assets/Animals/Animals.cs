using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor.SceneManagement;
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
        public Timer UpgradeTime { get; private set; }
        public Timer Eating { get; private set; }


		public event Action OnChange;
        public event Action LevelUp;


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

            UpgradeTime = new Timer(5);
            UpgradeTime.OnTimerEnd += Upgrade;

            Eating = new Timer(7);
            Eating.OnTimerEnd += Eat;
            Eating.OnTimerEnd += Drink;

            moneyperclick = GameObject.FindGameObjectWithTag("Money").GetComponent<MoneyPerClick>();
			IncomeMoney.ResourceTimer.OnTimerEnd += GetMoney;
		}

		public void InitializeLevels()
        {
            levels.Add(new AnimalLevel(1, config1.RequiredWater, config1.RequiredFood, config1.MoneyPerClick, config1.MoneyPerSecond, config1.WaterForUpgrade, config1.FoodForUpgrade));
			levels.Add(new AnimalLevel(2, config2.RequiredWater, config2.RequiredFood, config2.MoneyPerClick, config2.MoneyPerSecond, config2.WaterForUpgrade, config2.FoodForUpgrade));
			levels.Add(new AnimalLevel(3, config3.RequiredWater, config3.RequiredFood, config3.MoneyPerClick, config3.MoneyPerSecond, config3.WaterForUpgrade, config3.FoodForUpgrade));
			levels.Add(new AnimalLevel(4, config4.RequiredWater, config4.RequiredFood, config4.MoneyPerClick, config4.MoneyPerSecond, config4.WaterForUpgrade, config4.FoodForUpgrade));
		}

		public void UpdateData()
        {
            waterbuildingscript = WaterBuilding.GetComponent<WaterBuilding>();
            foodbuildingscript = FoodBuilding.GetComponent<FoodBuilding>();
		}

        public void Eat()
        {
            if (CurrentLevel.RequiredFood > foodbuildingscript.GetData()) Debug.Log("Недостаточно еды");
            else
            {
                foodbuildingscript.SetData(CurrentLevel.RequiredFood);
                Debug.Log("я поел");
            }
		}

        public void Drink()
        {
            if (CurrentLevel.RequiredWater > waterbuildingscript.GetData()) Debug.Log("Недостаточно воды");
            else
            {
                waterbuildingscript.SetData(CurrentLevel.RequiredWater);
                Debug.Log("я попил");
            }

			Eating.ResetTimer(false);
		}

        public void GetMoney()
        {
            if ((waterbuildingscript.GetData() < CurrentLevel.RequiredWater || foodbuildingscript.GetData() < CurrentLevel.RequiredFood)) moneyperclick.UpdateDataPerSecond(1);
            else moneyperclick.UpdateDataPerSecond(IncomeMoney.IncomePerSecondValue);
        }

        public void Upgrade()
        {
            if (waterbuildingscript.GetData() < CurrentLevel.WaterForUpgrade || foodbuildingscript.GetData() < CurrentLevel.FoodForUpgrade) return;

            waterbuildingscript.SetData(CurrentLevel.WaterForUpgrade);
            foodbuildingscript.SetData(CurrentLevel.FoodForUpgrade);

            CurrentLevel = levels[CurrentLevel.CurrentLevelNumber];

            IncomeMoney.IncomePerSecondValue = CurrentLevel.MoneyPerSecond;
            IncomeMoney.IncomePerClickValue = CurrentLevel.MoneyPerClick;

            UpgradeTime.ResetTimer(false);
            Debug.Log($"Данные моего нового уровня: {CurrentLevel.RequiredWater}, {CurrentLevel.RequiredFood}, {CurrentLevel.MoneyPerClick}, {CurrentLevel.MoneyPerSecond}, {CurrentLevel.WaterForUpgrade}, {CurrentLevel.FoodForUpgrade}");

            LevelUp?.Invoke();
        }

		public void Update()
		{
            IncomeMoney.Update(Time.deltaTime);
            if (CurrentLevel.RequiredWater <= waterbuildingscript.GetData() && CurrentLevel.RequiredFood <= foodbuildingscript.GetData()) Eating.Tick(Time.deltaTime);
            if (CurrentLevel.CurrentLevelNumber < 4 && waterbuildingscript.GetData() >= CurrentLevel.WaterForUpgrade && foodbuildingscript.GetData() >= CurrentLevel.FoodForUpgrade) UpgradeTime.Tick(Time.deltaTime);
		}
	}
}
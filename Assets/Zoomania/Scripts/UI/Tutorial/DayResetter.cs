using UnityEngine;

public class DayResetter : MonoBehaviour
{
    [Tooltip("Ссылка на компонент Day_And_Night")]
    public Day_And_Night dayAndNight;

    public void RestartDay()
    {
        if (dayAndNight == null)
        {
            Debug.LogWarning("DayResetter: Не назначен компонент Day_And_Night.");
            return;
        }

        dayAndNight.DayTime.ResetTimer(true);  
        dayAndNight.ChangeColorAlpha(0);       
        dayAndNight.Day();                     

        Debug.Log("DayResetter: День перезапущен с нуля.");
    }
}

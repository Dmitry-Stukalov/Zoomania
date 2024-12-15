using System.Collections;
using UnityEngine;

public class PandaAI : MonoBehaviour
{
    // Параметры камеры для расчета границ
    private Camera mainCamera;
    private Vector2 screenBounds;

    // Время задержки между действиями панды
    private float actionCooldown = 5f;

    // Флаги состояний
    private bool isMoving = false;

    // Стартовая функция
    void Start()
    {
        mainCamera = Camera.main;
        CalculateScreenBounds(); // Рассчитываем границы экрана
        StartCoroutine(PerformActions()); // Запускаем цикл действий
    }

    // Функция для расчета адаптивных границ экрана
    void CalculateScreenBounds()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    // Основная корутина случайных действий панды
    IEnumerator PerformActions()
    {
        while (true)
        {
            // Случайный выбор действия (0 = ходьба, 1 = отдых, 2 = еда, 3 = питье)
            int action = Random.Range(0, 4);

            switch (action)
            {
                case 0:
                    StartWalking();  // Ходьба
                    break;
                case 1:
                    StartResting();  // Отдых
                    break;
                case 2:
                    StartEating();   // Еда (пока без логики потребления)
                    break;
                case 3:
                    StartDrinking(); // Питье (пока без логики потребления)
                    break;
            }

            yield return new WaitForSeconds(actionCooldown); // Задержка перед следующим действием
        }
    }

    // Метод для начала движения
    void StartWalking()
    {
        if (!isMoving)
        {
            isMoving = true;
            Vector2 randomTarget = GetRandomPointWithinBounds(); // Случайная точка в пределах экрана
            StartCoroutine(WalkToPoint(randomTarget));
        }
    }

    // Метод для получения случайной точки в пределах адаптивных границ экрана
    Vector2 GetRandomPointWithinBounds()
    {
        float randomX = Random.Range(-screenBounds.x, screenBounds.x);
        float randomY = Random.Range(-screenBounds.y, screenBounds.y);
        return new Vector2(randomX, randomY);
    }

    // Корутина для передвижения панды к выбранной точке
    IEnumerator WalkToPoint(Vector2 targetPoint)
    {
        while (Vector2.Distance(transform.position, targetPoint) > 0.1f)
        {
            // Двигаем панду к точке
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, Time.deltaTime);
            yield return null;
        }

        isMoving = false; // После завершения движения сбрасываем флаг
    }

    // Метод для начала отдыха
    void StartResting()
    {
        // Логика отдыха
        Debug.Log("Панда отдыхает");
    }

    // Метод для начала еды
    void StartEating()
    {
        // Логика еды
        Debug.Log("Панда ест");
    }

    // Метод для начала питья
    void StartDrinking()
    {
        // Логика питья
        Debug.Log("Панда пьёт");
    }
}
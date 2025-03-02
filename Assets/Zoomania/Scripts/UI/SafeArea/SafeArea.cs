using UnityEngine;

public class SafeArea : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Rect _lastSafeArea;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        ApplySafeArea();
    }

    void ApplySafeArea()
    {
        Rect safeArea = Screen.safeArea;

        if (safeArea != _lastSafeArea)
        {
            _lastSafeArea = safeArea;

            // Рассчитываем отступы
            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;

            // Нормализуем отступы
            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            // Применяем отступы к RectTransform
            _rectTransform.anchorMin = anchorMin;
            _rectTransform.anchorMax = anchorMax;
        }
    }

    void Update()
    {
        ApplySafeArea(); // На случай изменения ориентации экрана
    }
}
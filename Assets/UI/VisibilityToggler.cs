using UnityEngine;
using UnityEngine.UI;

public class VisibilityToggler : MonoBehaviour
{
    [Tooltip("Объект, который будет показан при скрытии текущего объекта")]
    public GameObject targetObjectToShow;

    private void Start()
    {
        if (targetObjectToShow == null)
        {
            Debug.LogError("Не указан объект");
            return;
        }

        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ToggleVisibility);
        }
    }

    public void ToggleVisibility()
    {
        if (targetObjectToShow == null)
        {
            Debug.LogWarning("Объект не установлен!");
            return;
        }

        gameObject.SetActive(false);

        targetObjectToShow.SetActive(true);
    }
}


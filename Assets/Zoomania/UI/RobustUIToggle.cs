using UnityEngine;
using UnityEngine.UI;

public class RobustUIToggle : MonoBehaviour
{
    [Tooltip("UI элементы, которые будут скрываться/показываться")]
    public GameObject[] targetUIElements;

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(ToggleUIVisibility);
        }
        else
        {
            Debug.LogError("Скрипт должен быть прикреплен к кнопке");
        }

        
    }

    private void ToggleUIVisibility()
    {
        if (targetUIElements == null || targetUIElements.Length == 0)
        {
            Debug.LogWarning("нечего переключать");
            return;
        }

        foreach (GameObject uiElement in targetUIElements)
        {
            if (uiElement != null)
            {
                uiElement.SetActive(!uiElement.activeSelf);
            }
            else
            {
                Debug.LogWarning("UI элемент равен null!");
            }
        }
    }
}

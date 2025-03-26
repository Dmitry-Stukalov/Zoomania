using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RobustUIToggle : MonoBehaviour, IPointerClickHandler
{
    [Tooltip("UI элементы, которые будут скрываться/показываться")]
    [field:SerializeField] private GameObject[] targetUIElements;
    private Button Button { get; set; }

    private void Start()
    {
        Button = GetComponent<Button>();
        /*if (button != null)
        {
            button.onClick.AddListener(ToggleUIVisibility);
        }
        else
        {
            Debug.LogError("Скрипт должен быть прикреплен к кнопке");
        }*/
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Button == null) return;


        ToggleUIVisibility();
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

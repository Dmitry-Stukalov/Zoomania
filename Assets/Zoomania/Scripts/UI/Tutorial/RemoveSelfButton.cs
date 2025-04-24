using UnityEngine;
using UnityEngine.UI;

public class RemoveSelfButton : MonoBehaviour
{
    public void RemoveButtonComponent()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            Destroy(button);
            Debug.Log($"RemoveSelfButton: Компонент Button удалён с объекта '{gameObject.name}'");
        }
        else
        {
            Debug.LogWarning($"RemoveSelfButton: Компонент Button не найден на объекте '{gameObject.name}'");
        }
    }
}

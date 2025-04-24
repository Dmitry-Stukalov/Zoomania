using UnityEngine;
using System.Collections.Generic;

public class UIObjectsToggleController : MonoBehaviour
{
    [System.Serializable]
    public class UIObjectEntry
    {
        public GameObject uiObject;  
        public bool setActive;      
    }

    [Tooltip("Список объектов и действий")]
    public List<UIObjectEntry> uiObjectsList = new List<UIObjectEntry>();

    public void ApplyToggleAll()
    {
        foreach (var entry in uiObjectsList)
        {
            if (entry.uiObject != null)
            {
                entry.uiObject.SetActive(entry.setActive);
            }
            else
            {
                Debug.LogWarning("Объект в списке не назначен!");
            }
        }
    }

    public void ToggleSingleObject(int index)
    {
        if (index >= 0 && index < uiObjectsList.Count)
        {
            var entry = uiObjectsList[index];
            if (entry.uiObject != null)
            {
                entry.uiObject.SetActive(entry.setActive);
            }
            else
            {
                Debug.LogWarning($"Объект с индексом {index} не назначен!");
            }
        }
        else
        {
            Debug.LogError($"Индекс {index} вне диапазона списка!");
        }
    }
}
using UnityEngine;
using System.Collections;

public class PandaLevelChecker : MonoBehaviour
{
    [Header("Основные настройки")]
    [SerializeField] private Transform _pandaContainer; 
    [SerializeField] private SmoothObjectSwitcher _objectSwitcher;

    [Header("UI элементы")]
    [SerializeField] private GameObject _panelToEnable;
    [SerializeField] private GameObject _panelToDisable;

    private void Update()
    {
        if (_pandaContainer == null || _pandaContainer.childCount == 0)
            return;

        GameObject panda = _pandaContainer.GetChild(0).gameObject;
        if (!panda.CompareTag("Panda"))
            return;

        SpriteRenderer renderer = panda.GetComponent<SpriteRenderer>();
        if (renderer == null || renderer.sprite == null)
            return;

        if (renderer.sprite.name.StartsWith("Панда_2"))
        {
            ExecuteActions();
        }
    }

    private void ExecuteActions()
    {
        if (_objectSwitcher != null)
        {
            _objectSwitcher.SafeSwitch();
        }

        if (_panelToDisable != null)
        {
            _panelToDisable.SetActive(false);
        }

        if (_panelToEnable != null)
        {
            _panelToEnable.SetActive(true);
        }

        enabled = false;
    }
}
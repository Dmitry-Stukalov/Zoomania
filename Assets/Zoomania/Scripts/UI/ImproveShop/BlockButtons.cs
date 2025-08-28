using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class BlockButtons : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject targetMenu;
    [SerializeField] private List<GameObject> blockingButtons = new List<GameObject>();
    [SerializeField] private GameObject buttons;
    [SerializeField] private To_Personal_Paddock personalPaddock;

    private bool isHidden = false;

    void Start()
    {
        if (blockingButtons.Count == 0 || targetMenu == null)
        {
            Debug.LogWarning("Не назначены необходимые объекты");
            return;
        }

        for (int i = 0; i < blockingButtons.Count; i++) blockingButtons[i].SetActive(false);

        targetMenu.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleMenu();
    }

    public void ToggleMenu()
    {
        targetMenu.SetActive(!targetMenu.activeSelf);

        if (targetMenu.activeSelf || personalPaddock.InPersonalPaddock)
        {
            buttons.SetActive(false);
        }
        else
        {
            buttons.SetActive(true);
        }

        UpdateButtonsInteractability();
    }

    void UpdateButtonsInteractability()
    {
        if (isHidden)
        {
            ForceUnblockButtons();
        }
        else
        {
            ForceBlockButtons();
        }
    }

    public void ForceBlockButtons()
    {
        foreach (var button in blockingButtons)
        {
            if (button != null)
            {
                button.SetActive(true);
            }
        }
        isHidden = true;
    }

    public void ForceUnblockButtons()
    {
        foreach (var button in blockingButtons)
        {
            if (button != null)
            {
                button.SetActive(false);
            }
        }
        isHidden = false;
    }
}
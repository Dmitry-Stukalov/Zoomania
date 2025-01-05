using UnityEngine;
using UnityEngine.UI;

public class ImproveStore : MonoBehaviour
{
    public GameObject targetMenu;
    public Button blockingButton;

    void Start()
    {
        if (blockingButton == null || targetMenu == null)
        {
            Debug.LogWarning("Не назначена кнопка");
            return;
        }

        UpdateButtonInteractability();

        targetMenu.SetActive(false);
    }

    public void ToggleMenu()
    {
        targetMenu.SetActive(!targetMenu.activeSelf);

        UpdateButtonInteractability();
    }

    void UpdateButtonInteractability()
    {
        if (blockingButton != null)
        {
            blockingButton.interactable = !targetMenu.activeSelf;
        }
    }

    public void ForceBlockButton()
    {
        if (blockingButton != null)
        {
            blockingButton.interactable = false;
        }
    }

    public void ForceUnblockButton()
    {
        if (blockingButton != null)
        {
            blockingButton.interactable = true;
        }
    }
}
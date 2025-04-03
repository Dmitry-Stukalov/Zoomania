using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImproveStore : MonoBehaviour, IPointerClickHandler
{
    [field: SerializeField] private GameObject TargetMenu { get; set; }
	[field: SerializeField] private GameObject BlockingButton { get; set; }
    [field: SerializeField] private GameObject Buttons;
    [field: SerializeField] private To_Personal_Paddock PersonalPaddock;
	private bool IsHide { get; set; } = false;

    void Start()
    {
        if (BlockingButton == null || TargetMenu == null)
        {
            Debug.LogWarning("Не назначена кнопка");
            return;
        }

        TargetMenu.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ToggleMenu();
    }

    public void ToggleMenu()
    {
        TargetMenu.SetActive(!TargetMenu.activeSelf);

        if (TargetMenu.activeSelf || PersonalPaddock.InPersonalPaddock)
        {
            Buttons.SetActive(false);
        }
        else Buttons.SetActive(true);

		UpdateButtonInteractability();
    }

    void UpdateButtonInteractability()
    {
        if (IsHide)
        {
            ForceUnblockButton();
        }
        else ForceBlockButton();
    }

    public void ForceBlockButton()
    {
		if (BlockingButton != null)
        {
            BlockingButton.SetActive(false);
            IsHide = true;
        }
	}

    public void ForceUnblockButton()
    {
		if (BlockingButton != null)
        {
            BlockingButton.SetActive(true);
			IsHide = false;
		}
	}
}
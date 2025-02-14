using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImproveStore : MonoBehaviour, IPointerClickHandler
{
    [field: SerializeField] private GameObject TargetMenu { get; set; }
	[field: SerializeField] private GameObject BlockingButton { get; set; }
	[field: SerializeField] GameObject FoodMenuResource { get; set; }
	[field: SerializeField] GameObject WaterMenuResource { get; set; }
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

		FoodMenuResource.GetComponent<Background_Resource>().SetAnimation();
		WaterMenuResource.GetComponent<Background_Resource>().SetAnimation();

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
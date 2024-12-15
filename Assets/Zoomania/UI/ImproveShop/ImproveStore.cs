using UnityEngine;
using UnityEngine.SceneManagement;

public class ImproveStore : MonoBehaviour
{
    private RectTransform rectTransform;

    public GameObject targetMenu;

    [Range(0, 100)] public float buttonSizePercent = 10f;
    [Range(0, 100)] public float bottomOffsetPercent = 5f;
    [Range(0, 100)] public float rightOffsetPercent = 5f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        SetupButton();
    }

    void SetupButton()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float buttonSize = Mathf.Min(screenWidth, screenHeight) * (buttonSizePercent / 100f);

        float bottomOffset = screenHeight * (bottomOffsetPercent / 100f);
        float rightOffset = screenWidth * (rightOffsetPercent / 100f);

        rectTransform.sizeDelta = new Vector2(buttonSize, buttonSize);
        rectTransform.anchorMin = new Vector2(1, 0);
        rectTransform.anchorMax = new Vector2(1, 0);
        rectTransform.pivot = new Vector2(1, 0);
        rectTransform.anchoredPosition = new Vector2(-rightOffset, bottomOffset);
    }

    public void ToggleMenu()
    {
        targetMenu.SetActive(!targetMenu.activeSelf);
    }
}

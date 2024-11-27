using UnityEngine;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    private RectTransform rectTransform;

    public Object sceneAsset; 

    [Range(0, 100)] public float buttonSizePercent = 10f; 
    [Range(0, 100)] public float bottomOffsetPercent = 5f; 
    [Range(0, 100)] public float leftOffsetPercent = 5f; 

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
        float leftOffset = screenWidth * (leftOffsetPercent / 100f);

        rectTransform.sizeDelta = new Vector2(buttonSize, buttonSize);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(0, 0);
        rectTransform.anchoredPosition = new Vector2(leftOffset, bottomOffset);
    }

    public void SwitchScene()
    {
        if (sceneAsset != null)
        {
            SceneManager.LoadScene(sceneAsset.name);
        }
    }
}
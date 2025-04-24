using UnityEngine;
using UnityEngine.UI;

public class ImageAlphaFader : MonoBehaviour
{
    [Tooltip("Целевой Image, чью прозрачность нужно изменять")]
    public Image targetImage;

    private float originalAlpha;

    private void Awake()
    {
        if (targetImage != null)
        {
            originalAlpha = targetImage.color.a;
        }
        else
        {
            Debug.LogWarning("ImageAlphaFader: Не назначен targetImage.");
        }
    }

    public void MakeTransparent()
    {
        if (targetImage == null) return;

        Color c = targetImage.color;
        c.a = 0f;
        targetImage.color = c;
    }

    public void RestoreAlpha()
    {
        if (targetImage == null) return;

        Color c = targetImage.color;
        c.a = originalAlpha;
        targetImage.color = c;
    }
}

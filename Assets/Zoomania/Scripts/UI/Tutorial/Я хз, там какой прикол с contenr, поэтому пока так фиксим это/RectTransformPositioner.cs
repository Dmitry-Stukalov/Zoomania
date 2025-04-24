using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class RectTransformPositioner : MonoBehaviour
{
    [Header("Offset Settings")]
    [SerializeField] private float topOffset = 0f;
    [SerializeField] private float bottomOffset = -1500f;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        ApplyOffsets();
    }

    private void ApplyOffsets()
    {
        if (rectTransform == null) return;

        float left = rectTransform.offsetMin.x;
        float right = rectTransform.offsetMax.x;

        rectTransform.offsetMin = new Vector2(left, bottomOffset);
        rectTransform.offsetMax = new Vector2(right, -topOffset);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class UIGlowPulseEffect : MonoBehaviour
{
    [SerializeField] public float scaleAmount = 1.05f;        
    [SerializeField] public float pulseSpeed = 2f;            
    [SerializeField] public Color glowColor = Color.yellow;   
    [SerializeField] public bool affectChildren = true;

    public Vector3 originalScale;
    public Graphic[] graphics;
    public Color[] originalColors;

    public void Awake()
    {
        originalScale = transform.localScale;

        graphics = affectChildren
            ? GetComponentsInChildren<Graphic>(true)
            : new Graphic[] { GetComponent<Graphic>() };

        originalColors = new Color[graphics.Length];
        for (int i = 0; i < graphics.Length; i++)
        {
            originalColors[i] = graphics[i].color;
        }
    }

    public void Update()
    {
        float pulse = (Mathf.Sin(Time.time * pulseSpeed) + 1f) / 2f;

        float scale = Mathf.Lerp(1f, scaleAmount, pulse);
        transform.localScale = originalScale * scale;

        for (int i = 0; i < graphics.Length; i++)
        {
            if (graphics[i] != null)
            {
                graphics[i].color = Color.Lerp(originalColors[i], glowColor, pulse);
            }
        }
    }

    public void OnDisable()
    {
        transform.localScale = originalScale;

        for (int i = 0; i < graphics.Length; i++)
        {
            if (graphics[i] != null)
            {
                graphics[i].color = originalColors[i];
            }
        }
    }
}

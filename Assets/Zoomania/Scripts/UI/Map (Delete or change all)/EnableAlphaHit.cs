using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EnableAlphaHit : MonoBehaviour
{
    void Start()
    {
        Image img = GetComponent<Image>();
        img.alphaHitTestMinimumThreshold = 0.1f; 
    }
}
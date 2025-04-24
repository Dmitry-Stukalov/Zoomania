using UnityEngine;
using System.Collections;

public class SmoothObjectSwitcher : MonoBehaviour
{
    [Header("Настройки переключения")]
    public GameObject objectToActivate;
    public float switchDelay = 0.3f;

    [Header("Настройки анимации исчезновения")]
    public float fadeOutDuration = 0.2f;
    public float scaleDownFactor = 0.6f;

    [Header("Настройки анимации появления")]
    public float fadeInDuration = 0.2f;
    public float scaleUpFactor = 0.8f;

    public void SafeSwitch()
    {
        if (!gameObject.activeInHierarchy)
        {
            Debug.Log("SmoothObjectSwitcher: Объект не активен, корутина не будет запущена.");
            return;
        }

        SwitchObjects();
    }

    public void SwitchObjects()
    {
        StartCoroutine(SwitchWithAnimations());
    }

    private IEnumerator SwitchWithAnimations()
    {
        if (TryGetComponent(out CanvasGroup currentCanvasGroup))
        {
            yield return StartCoroutine(FadeOut(currentCanvasGroup));
        }
        else
        {
            yield return StartCoroutine(ScaleDown());
        }

        yield return new WaitForSeconds(switchDelay);

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);

            if (objectToActivate.TryGetComponent(out CanvasGroup newCanvasGroup))
            {
                yield return StartCoroutine(FadeIn(newCanvasGroup));
            }
            else
            {
                yield return StartCoroutine(ScaleUp(objectToActivate.transform));
            }
        }

        Destroy(gameObject);
    }

    private IEnumerator FadeOut(CanvasGroup canvasGroup)
    {
        float elapsed = 0f;
        float startAlpha = canvasGroup.alpha;
        Vector3 startScale = transform.localScale;
        Vector3 endScale = startScale * scaleDownFactor;

        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeOutDuration;

            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, t);
            transform.localScale = Vector3.Lerp(startScale, endScale, t);

            yield return null;
        }

        canvasGroup.alpha = 0f;
        transform.localScale = endScale;
    }

    private IEnumerator ScaleDown()
    {
        float elapsed = 0f;
        Vector3 startScale = transform.localScale;
        Vector3 endScale = startScale * scaleDownFactor;

        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startScale, endScale, elapsed / fadeOutDuration);
            yield return null;
        }

        transform.localScale = endScale;
    }

    private IEnumerator FadeIn(CanvasGroup canvasGroup)
    {
        float elapsed = 0f;
        float endAlpha = canvasGroup.alpha;
        canvasGroup.alpha = 0f;

        Vector3 startScale = objectToActivate.transform.localScale * scaleUpFactor;
        Vector3 endScale = objectToActivate.transform.localScale;
        objectToActivate.transform.localScale = startScale;

        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeInDuration;

            canvasGroup.alpha = Mathf.Lerp(0f, endAlpha, t);
            objectToActivate.transform.localScale = Vector3.Lerp(startScale, endScale, t);

            yield return null;
        }

        canvasGroup.alpha = endAlpha;
        objectToActivate.transform.localScale = endScale;
    }

    private IEnumerator ScaleUp(Transform targetTransform)
    {
        float elapsed = 0f;
        Vector3 startScale = targetTransform.localScale * scaleUpFactor;
        Vector3 endScale = targetTransform.localScale;
        targetTransform.localScale = startScale;

        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            targetTransform.localScale = Vector3.Lerp(startScale, endScale, elapsed / fadeInDuration);
            yield return null;
        }

        targetTransform.localScale = endScale;
    }
}

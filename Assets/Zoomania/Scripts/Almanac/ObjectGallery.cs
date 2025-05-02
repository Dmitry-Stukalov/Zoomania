using Animal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;

public class ObjectGallery : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private float _swipeThreshold = 100f;
    [SerializeField] private float _swipeAnimationDuration = 0.3f;
    [SerializeField] private Image _displayImage;
	[SerializeField] private TextMeshProUGUI _name;
	[SerializeField] private TextMeshProUGUI _level;
	[SerializeField] private TextMeshProUGUI _water;
	[SerializeField] private TextMeshProUGUI _food;
	[SerializeField] private TextMeshProUGUI _essenceTime;
	[SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private List<Panda_Levels_Config> _pandas;
    [SerializeField] private AudioClip _swipeSound;

    private int _currentAnimalIndex = 0;
    private int _currentLevelIndex = 0;
    private Vector2 _dragStartPosition;
    private bool _isAnimating;

    private void Start()
    {
        UpdateDisplay();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_isAnimating) return;
        _dragStartPosition = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isAnimating) return;

        Vector2 dragDelta = eventData.position - _dragStartPosition;

        if (Mathf.Abs(dragDelta.x) > Mathf.Abs(dragDelta.y))
        {
            if (Mathf.Abs(dragDelta.x) > _swipeThreshold)
            {
                if (dragDelta.x > 0) PreviousAnimal();
                else NextAnimal();
            }
            else
            {
                StartCoroutine(CancelSwipeAnimation(Vector3.right));
            }
        }
        else
        {
            if (Mathf.Abs(dragDelta.y) > _swipeThreshold)
            {
                if (dragDelta.y > 0) PreviousLevel();
                else NextLevel();
            }
            else
            {
                StartCoroutine(CancelSwipeAnimation(Vector3.up));
            }
        }
    }

    private void NextAnimal()
    {
        _currentAnimalIndex = (_currentAnimalIndex + 1) % _pandas.Count;
        _currentLevelIndex = 0;
        StartCoroutine(SwipeAnimation(Vector3.left));
        PlaySwipeSound();
    }

    private void PreviousAnimal()
    {
        _currentAnimalIndex = (_currentAnimalIndex - 1 + _pandas.Count) % _pandas.Count;
        _currentLevelIndex = 0;
        StartCoroutine(SwipeAnimation(Vector3.right));
        PlaySwipeSound();
    }

    private void NextLevel()
    {
        var levels = _pandas[_currentAnimalIndex].levels;
        _currentLevelIndex = (_currentLevelIndex + 1) % levels.Count;
        StartCoroutine(SwipeAnimation(Vector3.down));
        PlaySwipeSound();
    }

    private void PreviousLevel()
    {
        var levels = _pandas[_currentAnimalIndex].levels;
        _currentLevelIndex = (_currentLevelIndex - 1 + levels.Count) % levels.Count;
        StartCoroutine(SwipeAnimation(Vector3.up));
        PlaySwipeSound();
    }

    private IEnumerator SwipeAnimation(Vector3 direction)
    {
        _isAnimating = true;
        RectTransform imageTransform = _displayImage.rectTransform;
        Vector3 startPos = imageTransform.localPosition;
        Vector3 endPos = direction.normalized * _swipeThreshold;

        Vector3 startScale = Vector3.one;
        Vector3 endScale = Vector3.one * 0.7f;

        CanvasGroup canvasGroup = _displayImage.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = _displayImage.gameObject.AddComponent<CanvasGroup>();
        }

        float elapsed = 0f;
        while (elapsed < _swipeAnimationDuration / 2)
        {
            float t = elapsed / (_swipeAnimationDuration / 2);
            imageTransform.localPosition = Vector3.Lerp(startPos, endPos, EaseInOut(t));
            imageTransform.localScale = Vector3.Lerp(startScale, endScale, EaseInOut(t));
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        UpdateDisplay();

        imageTransform.localPosition = -endPos;
        imageTransform.localScale = endScale;
        canvasGroup.alpha = 0f;

        elapsed = 0f;
        while (elapsed < _swipeAnimationDuration / 2)
        {
            float t = elapsed / (_swipeAnimationDuration / 2);
            imageTransform.localPosition = Vector3.Lerp(-endPos, Vector3.zero, EaseInOut(t));
            imageTransform.localScale = Vector3.Lerp(endScale, Vector3.one, EaseOutBounce(t));
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, t);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        imageTransform.localPosition = Vector3.zero;
        imageTransform.localScale = Vector3.one;
        canvasGroup.alpha = 1f;
        _isAnimating = false;
    }

    private IEnumerator CancelSwipeAnimation(Vector3 direction)
    {
        RectTransform imageTransform = _displayImage.rectTransform;
        Vector3 currentPos = imageTransform.localPosition;

        float elapsed = 0f;
        while (elapsed < 0.2f)
        {
            imageTransform.localPosition = Vector3.Lerp(currentPos, Vector3.zero, elapsed / 0.2f);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        imageTransform.localPosition = Vector3.zero;
    }

    private void UpdateDisplay()
    {
        AnimalLevel level = _pandas[_currentAnimalIndex].levels[_currentLevelIndex];
        _displayImage.sprite = level.View;
        _name.text = level.Name;
        _level.text = $"Уровень: {level.CurrentLevelNumber}";
        _water.text = level.RequiredWater.ToString();
        _food.text = level.RequiredFood.ToString();
        _essenceTime.text = $"{level.EssenceSpawnTimer} сек";
        _descriptionText.text = level.Description;
    }

    private void PlaySwipeSound()
    {
        if (_swipeSound != null)
            AudioSource.PlayClipAtPoint(_swipeSound, Camera.main.transform.position);
    }

    private float EaseInOut(float t)
    {
        return t * t * (3f - 2f * t);
    }

    private float EaseOutBounce(float t)
    {
        if (t < 1 / 2.75f) return 7.5625f * t * t;
        else if (t < 2 / 2.75f)
        {
            t -= 1.5f / 2.75f;
            return 7.5625f * t * t + 0.75f;
        }
        else if (t < 2.5f / 2.75f)
        {
            t -= 2.25f / 2.75f;
            return 7.5625f * t * t + 0.9375f;
        }
        else
        {
            t -= 2.625f / 2.75f;
            return 7.5625f * t * t + 0.984375f;
        }
    }
}

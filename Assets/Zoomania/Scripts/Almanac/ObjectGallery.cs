using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class ObjectGallery : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private float _swipeThreshold = 100f;
    [SerializeField] private float _swipeAnimationDuration = 0.3f;
    [SerializeField] private Image _displayImage;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private List<ObjectData> _objects;
    [SerializeField] private List<Image> _pageIndicators;
    [SerializeField] private AudioClip _swipeSound;

    private int _currentIndex = 0;
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

        if (Mathf.Abs(dragDelta.x) > _swipeThreshold)
        {
            if (dragDelta.x > 0) PreviousObject();
            else NextObject();
        }
        else
        {
            StartCoroutine(CancelSwipeAnimation());
        }
    }

    private void NextObject()
    {
        _currentIndex = (_currentIndex + 1) % _objects.Count;
        StartCoroutine(SwipeAnimation(-1));
        PlaySwipeSound();
    }

    private void PreviousObject()
    {
        _currentIndex = (_currentIndex - 1 + _objects.Count) % _objects.Count;
        StartCoroutine(SwipeAnimation(1));
        PlaySwipeSound();
    }

    private IEnumerator SwipeAnimation(int direction)
    {
        _isAnimating = true;
        RectTransform imageTransform = _displayImage.rectTransform;
        Vector3 startPos = imageTransform.localPosition;
        Vector3 endPos = new Vector3(_swipeThreshold * direction, 0, 0);

        float elapsed = 0f;
        while (elapsed < _swipeAnimationDuration / 2)
        {
            imageTransform.localPosition = Vector3.Lerp(startPos, endPos, elapsed / (_swipeAnimationDuration / 2));
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        UpdateDisplay();

        imageTransform.localPosition = new Vector3(-_swipeThreshold * direction, 0, 0);
        elapsed = 0f;
        while (elapsed < _swipeAnimationDuration / 2)
        {
            imageTransform.localPosition = Vector3.Lerp(
                new Vector3(-_swipeThreshold * direction, 0, 0),
                Vector3.zero,
                elapsed / (_swipeAnimationDuration / 2));
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        imageTransform.localPosition = Vector3.zero;
        _isAnimating = false;
    }

    private IEnumerator CancelSwipeAnimation()
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
        _displayImage.sprite = _objects[_currentIndex].objectImage;
        _descriptionText.text = _objects[_currentIndex].objectDescription;
        UpdateIndicators();
    }

    private void UpdateIndicators()
    {
        for (int i = 0; i < _pageIndicators.Count; i++)
        {
            _pageIndicators[i].color = (i == _currentIndex) ? Color.white : Color.gray;
        }
    }

    private void PlaySwipeSound()
    {
        if (_swipeSound != null)
            AudioSource.PlayClipAtPoint(_swipeSound, Camera.main.transform.position);
    }
}
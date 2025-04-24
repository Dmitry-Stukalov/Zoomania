using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class PandaChecker2D : MonoBehaviour
{
    [SerializeField] private Transform _animalPlace;
    [SerializeField] private TextMeshProUGUI _statusText;
    [SerializeField] private SmoothObjectSwitcher _smoothSwitcher;
    [SerializeField] private float _pulseDuration = 0.3f;
    [SerializeField] private float _maxScale = 1.2f;
    [SerializeField] private int _pulseCount = 2;
    [SerializeField] private Color _errorColor = Color.red;
    [SerializeField] private Color _normalColor = Color.white;

    private Vector3 _originalTextScale;
    private Color _originalTextColor;
    private Coroutine _animationCoroutine;

    private void Awake()
    {
        if (_statusText != null)
        {
            _originalTextScale = _statusText.transform.localScale;
            _originalTextColor = _statusText.color;
        }
    }

    private void OnMouseDown()
    {
        if (_animalPlace == null) return;

        if (_animalPlace.childCount == 0)
        {
            if (_animationCoroutine != null)
            {
                StopCoroutine(_animationCoroutine);
            }
            _animationCoroutine = StartCoroutine(ShowErrorAnimation());
        }
        else
        {
            if (_smoothSwitcher != null)
            {
                _smoothSwitcher.SafeSwitch();
            }
            Destroy(gameObject);
        }
    }

    private IEnumerator ShowErrorAnimation()
    {
        if (_statusText != null)
        {
            _statusText.color = _errorColor;
        }

        for (int i = 0; i < _pulseCount; i++)
        {
            float timer = 0f;
            while (timer < _pulseDuration)
            {
                float progress = timer / _pulseDuration;
                float scale = Mathf.Lerp(1f, _maxScale, progress);
                _statusText.transform.localScale = _originalTextScale * scale;
                timer += Time.deltaTime;
                yield return null;
            }

            timer = 0f;
            while (timer < _pulseDuration)
            {
                float progress = timer / _pulseDuration;
                float scale = Mathf.Lerp(_maxScale, 1f, progress);
                _statusText.transform.localScale = _originalTextScale * scale;
                timer += Time.deltaTime;
                yield return null;
            }
        }

        if (_statusText != null)
        {
            _statusText.color = _originalTextColor;
            _statusText.transform.localScale = _originalTextScale;
        }
    }
}
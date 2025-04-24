using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SequentialObjectMover : MonoBehaviour
{
    [System.Serializable]
    public class MovableObject
    {
        public Transform targetObject;
        public Transform newParent;
        public bool useAnimation = true;
    }

    [SerializeField] private List<MovableObject> _objects = new List<MovableObject>();
    [SerializeField] private float _scaleAmount = 1.05f;
    [SerializeField] private float _pulseSpeed = 2f;
    [SerializeField] private Color _glowColor = Color.yellow;
    [SerializeField] private bool _affectChildren = true;

    private List<Transform> _originalParents = new List<Transform>();
    private List<UIGlowPulseEffect> _glowEffects = new List<UIGlowPulseEffect>();
    private int _currentIndex = -1;
    private bool _isMoved = false;
    private bool _pendingMove = false;

    private void Start()
    {
        foreach (var obj in _objects)
        {
            _originalParents.Add(obj.targetObject.parent);

            if (obj.useAnimation)
            {
                var effect = obj.targetObject.gameObject.AddComponent<UIGlowPulseEffect>();
                effect.scaleAmount = _scaleAmount;
                effect.pulseSpeed = _pulseSpeed;
                effect.glowColor = _glowColor;
                effect.affectChildren = _affectChildren;
                effect.enabled = false;
                _glowEffects.Add(effect);
            }
            else
            {
                _glowEffects.Add(null);
            }
        }
    }

    private void LateUpdate()
    {
        if (_pendingMove)
        {
            ExecutePendingMove();
            _pendingMove = false;
        }
    }

    public void MoveNext()
    {
        if (_currentIndex >= _objects.Count - 1 || _isMoved) return;

        _pendingMove = true;
    }

    private void ExecutePendingMove()
    {
        _currentIndex++;
        var currentObj = _objects[_currentIndex];
        currentObj.targetObject.SetParent(currentObj.newParent);

        if (_glowEffects[_currentIndex] != null)
        {
            _glowEffects[_currentIndex].enabled = true;
        }

        _isMoved = true;
    }

    public void ReturnCurrent()
    {
        if (_currentIndex < 0 || !_isMoved) return;

        var currentObj = _objects[_currentIndex];
        currentObj.targetObject.SetParent(_originalParents[_currentIndex]);

        if (_glowEffects[_currentIndex] != null)
        {
            _glowEffects[_currentIndex].enabled = false;
        }

        _isMoved = false;
    }

    public void Reset()
    {
        _currentIndex = -1;
        _isMoved = false;
    }
}
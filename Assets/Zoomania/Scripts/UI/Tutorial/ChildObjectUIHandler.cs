using UnityEngine;

public class CameraPositionUIHandler : MonoBehaviour
{
    [SerializeField] private Camera _targetCamera;
    [SerializeField] private Vector3 _targetCameraPosition = new Vector3(-23f, 0f, 20f);
    [SerializeField] private Vector3 _returnCameraPosition = new Vector3(0f, 0f, -20f);
    [SerializeField] private float _positionThreshold = 0.1f;
    [SerializeField] private GameObject _uiElementToDisable;
    [SerializeField] private GameObject _uiElementToEnable;
    [SerializeField] private GameObject _uiElementToActivateOnReturn;

    private bool _wasDisabled;
    private bool _wasEnabled;
    private bool _wasAtTargetPosition;
    private bool _returnUIActivated;

    private void Update()
    {
        bool isAtTargetPosition = Vector3.Distance(_targetCamera.transform.position, _targetCameraPosition) <= _positionThreshold;
        bool isAtReturnPosition = Vector3.Distance(_targetCamera.transform.position, _returnCameraPosition) <= _positionThreshold;

        if (isAtTargetPosition)
        {
            if (!_wasDisabled && _uiElementToDisable != null && _uiElementToDisable.activeSelf)
            {
                _uiElementToDisable.SetActive(false);
                _wasDisabled = true;
            }

            if (!_wasEnabled && _uiElementToEnable != null && !_uiElementToEnable.activeSelf)
            {
                _uiElementToEnable.SetActive(true);
                _wasEnabled = true;
            }
            _wasAtTargetPosition = true;
        }

        if (_wasAtTargetPosition && isAtReturnPosition && !_returnUIActivated)
        {
            if (_uiElementToActivateOnReturn != null && !_uiElementToActivateOnReturn.activeSelf)
            {
                _uiElementToActivateOnReturn.SetActive(true);
                _returnUIActivated = true;
            }
        }
    }

    public void ResetState()
    {
        _wasDisabled = false;
        _wasEnabled = false;
        _wasAtTargetPosition = false;
        _returnUIActivated = false;
    }
}
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _uiElementToToggle;
    [SerializeField] private bool _disableOnClick = true;

    private void OnMouseDown()
    {
        if (_uiElementToToggle != null)
        {
            _uiElementToToggle.SetActive(!_uiElementToToggle.activeSelf);

            if (_disableOnClick)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
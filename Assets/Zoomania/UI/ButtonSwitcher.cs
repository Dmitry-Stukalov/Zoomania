using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitcher : MonoBehaviour
{
    public GameObject buttonToShow;  

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();

        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    void OnButtonClick()
    {
        gameObject.SetActive(false);

        if (buttonToShow != null)
            buttonToShow.SetActive(true);
    }
}
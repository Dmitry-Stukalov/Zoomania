using UnityEngine;

public class NightEventResponder : MonoBehaviour
{
    public Day_And_Night dayAndNight;
    public GameObject tutorialOverlay;
    public GameObject objectWithSwitcher;

    private SequentialObjectMover mover;
    private SmoothObjectSwitcher switcher;

    private void Awake()
    {
        if (tutorialOverlay != null)
            mover = tutorialOverlay.GetComponent<SequentialObjectMover>();

        if (objectWithSwitcher != null)
            switcher = objectWithSwitcher.GetComponent<SmoothObjectSwitcher>();
    }

    private void OnEnable()
    {
        if (dayAndNight != null)
            dayAndNight.OnNight += HandleNight;
    }

    private void OnDisable()
    {
        if (dayAndNight != null)
            dayAndNight.OnNight -= HandleNight;
    }

    private void HandleNight()
    {
        if (mover != null)
        {
            mover.ReturnCurrent();
            mover.MoveNext();
        }

        if (switcher != null)
            switcher.SwitchObjects();

        Debug.Log("NightEventResponder: Вызваны методы на наступление ночи.");
    }
}

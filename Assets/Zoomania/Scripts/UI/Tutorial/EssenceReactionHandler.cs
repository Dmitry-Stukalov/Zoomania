using UnityEngine;

public class EssenceReactionHandler : MonoBehaviour
{
    public Essence_Storage essenceStorage;
    public GameObject tutorialOverlay;
    public GameObject objectWithSwitcher;
    public GameObject objectWithAlphaFader;

    private SequentialObjectMover mover;
    private SmoothObjectSwitcher switcher;
    private ImageAlphaFader alphaFader;

    private bool alreadyTriggered = false;

    private void Awake()
    {
        if (tutorialOverlay != null)
            mover = tutorialOverlay.GetComponent<SequentialObjectMover>();

        if (objectWithSwitcher != null)
            switcher = objectWithSwitcher.GetComponent<SmoothObjectSwitcher>();

        if (objectWithAlphaFader != null)
            alphaFader = objectWithAlphaFader.GetComponent<ImageAlphaFader>();
    }

    private void OnEnable()
    {
        if (essenceStorage != null)
            essenceStorage.OnChange += HandleEssenceChange;
    }

    private void OnDisable()
    {
        if (essenceStorage != null)
            essenceStorage.OnChange -= HandleEssenceChange;
    }

    private void HandleEssenceChange()
    {
        if (alreadyTriggered || essenceStorage.GetEssenceCount() != 1)
            return;

        alreadyTriggered = true;

        if (mover != null)
        {
            mover.ReturnCurrent();
            mover.MoveNext();
        }

        if (switcher != null)
            switcher.SwitchObjects();

        if (alphaFader != null)
            alphaFader.RestoreAlpha();

        Debug.Log("EssenceReactionHandler: ѕерва€ эссенци€ собрана Ч вызваны все нужные методы.");
    }
}

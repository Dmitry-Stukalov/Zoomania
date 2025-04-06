using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public GameObject targetObject;
    public Camera mainCamera;

    [Header("Теги панелей, при активных которых targetObject отключается")]
    public List<string> disablingPanelTags = new List<string>();

    [Header("Условия камеры для полного отключения")]
    public float cameraSizeThreshold = 5f;
    public Vector3 cameraPositionThreshold = new Vector3(-23f, 0f, -20f);

    private List<GameObject> panelsToCheck = new List<GameObject>();

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (string tag in disablingPanelTags)
        {
            foreach (GameObject obj in allObjects)
            {
                if (obj.CompareTag(tag) && !panelsToCheck.Contains(obj))
                {
                    panelsToCheck.Add(obj);
                }
            }
        }

        if (panelsToCheck.Count == 0)
        {
            Debug.LogWarning("Ни одного объекта с указанными тегами не найдено");
        }
    }

    void Update()
    {
        if (targetObject == null || mainCamera == null)
            return;

        bool cameraCondition = Mathf.Approximately(mainCamera.orthographicSize, cameraSizeThreshold) &&
                              Vector3.Distance(mainCamera.transform.position, cameraPositionThreshold) < 0.01f;

        if (cameraCondition)
        {
            if (targetObject.activeSelf)
                targetObject.SetActive(false);
            return;
        }

        bool anyPanelActive = false;
        foreach (GameObject panel in panelsToCheck)
        {
            if (panel != null && panel.activeInHierarchy)
            {
                anyPanelActive = true;
                break;
            }
        }

        if (anyPanelActive)
        {
            if (targetObject.activeSelf)
                targetObject.SetActive(false);
        }
        else
        {
            if (!targetObject.activeSelf)
                targetObject.SetActive(true);
        }
    }
}
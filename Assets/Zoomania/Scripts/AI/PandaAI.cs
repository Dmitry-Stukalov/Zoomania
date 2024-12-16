using System.Collections;
using UnityEngine;

public class PandaAI : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;

    private float actionCooldown = 5f;

    private bool isMoving = false;

    void Start()
    {
        mainCamera = Camera.main;
        CalculateScreenBounds(); 
        StartCoroutine(PerformActions()); 
    }

    void CalculateScreenBounds()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    IEnumerator PerformActions()
    {
        while (true)
        {
            int action = Random.Range(0, 4);

            switch (action)
            {
                case 0:
                    StartWalking(); 
                    break;
                case 1:
                    StartResting();  
                    break;
                case 2:
                    StartEating();  
                    break;
                case 3:
                    StartDrinking(); 
                    break;
            }

            yield return new WaitForSeconds(actionCooldown); 
        }
    }

    void StartWalking()
    {
        if (!isMoving)
        {
            isMoving = true;
            Vector2 randomTarget = GetRandomPointWithinBounds(); 
            StartCoroutine(WalkToPoint(randomTarget));
        }
    }

    Vector2 GetRandomPointWithinBounds()
    {
        float randomX = Random.Range(-screenBounds.x, screenBounds.x);
        float randomY = Random.Range(-screenBounds.y, screenBounds.y);
        return new Vector2(randomX, randomY);
    }

    IEnumerator WalkToPoint(Vector2 targetPoint)
    {
        while (Vector2.Distance(transform.position, targetPoint) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint, Time.deltaTime);
            yield return null;
        }

        isMoving = false; 
    }

    void StartResting()
    {
        Debug.Log("Панда отдыхает");
    }

    void StartEating()
    {
        Debug.Log("Панда ест");
    }

    void StartDrinking()
    {
        Debug.Log("Панда пьёт");
    }
}
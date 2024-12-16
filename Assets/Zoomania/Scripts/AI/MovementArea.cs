using UnityEngine;

public class MovementArea : MonoBehaviour
{
    [Header("Movement Bounds")]
    public float MinX = -1.632f;
    public float MaxX = 1.648f;
    public float MinY = -3.952f;
    public float MaxY = 1.763f;

    public Vector2 GetRandomPointWithinBounds()
    {
        float randomX = Random.Range(MinX, MaxX);
        float randomY = Random.Range(MinY, MaxY);
        return new Vector2(randomX, randomY);
    }

    public bool IsPointWithinBounds(Vector2 point)
    {
        return point.x >= MinX && point.x <= MaxX &&
               point.y >= MinY && point.y <= MaxY;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Vector3 center = new Vector3((MinX + MaxX) / 2, (MinY + MaxY) / 2, 0);
        Vector3 size = new Vector3(MaxX - MinX, MaxY - MinY, 0);
        Gizmos.DrawWireCube(center, size);
    }
}
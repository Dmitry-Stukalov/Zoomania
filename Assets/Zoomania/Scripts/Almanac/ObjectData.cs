using UnityEngine;

[CreateAssetMenu(fileName = "New ObjectData", menuName = "Almanac/New Snus")]
public class ObjectData : ScriptableObject
{
    public Sprite objectImage;
    [TextArea(3, 10)] public string objectDescription;
}
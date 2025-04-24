using UnityEngine;

public class MoveToBottomInHierarchy : MonoBehaviour
{
    private void OnEnable()
    {
        MoveToBottom();
    }

    public void MoveToBottom()
    {
        if (transform.parent != null)
        {
            transform.SetAsLastSibling(); 
        }
    }
}
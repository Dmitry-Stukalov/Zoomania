using UnityEngine;

public class FakeChild : MonoBehaviour
{
    [SerializeField] private Transform _parent; 
    [SerializeField] private Vector3 _offset;  

    private void Update()
    {
        if (_parent != null)
        {
            transform.position = _parent.position + _offset;
        }
    }
}
using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField] private Transform _followingObject;
    [SerializeField] private Vector3 _offset;

    private void Update()
    {
        transform.position = _followingObject.position + _offset;        
    }
}

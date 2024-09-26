using UnityEngine;

public class Following : MonoBehaviour
{
    [SerializeField] Transform _followingObject;
    [SerializeField] Vector3 _offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = _followingObject.position + _offset;        
    }
}

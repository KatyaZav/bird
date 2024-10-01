using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField] private PointMover _pointMover;

    void FixedUpdate()
    {
        _pointMover.FixedMove();
    }
}

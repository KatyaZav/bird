using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private BirdJumper _bird;
    [SerializeField] private float _reactionTime;

    private bool _isRight;
    private float _timeSinceMove;

    void FixedUpdate()
    {
        _timeSinceMove += Time.time;

        if (_reactionTime >= _timeSinceMove)
            return;

        if (transform.position.y < _point.transform.position.y)
        {
            _bird.Jump();
            _timeSinceMove = 0;
        }

        Debug.Log($"{transform.position.x}  {_point.transform.position.x} && {_isRight}");

        if (transform.position.x < _point.transform.position.x && _isRight == false)
        {
            _bird.Swipe();
            _isRight = true;
            _timeSinceMove = 0;
        }

        if (transform.position.x < _point.transform.position.x && _isRight)
        {
            _bird.Swipe();
            _isRight = false;
            _timeSinceMove = 0;
        }
    }
}

using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField] private Transform _point;
    [SerializeField] private BirdJumper _bird;
    [SerializeField] private float _reactionTime;
    [SerializeField] private float _maxDirection = 0.05f;

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

        var direction = _point.transform.position - _bird.transform.position;
        if (direction.magnitude <= _maxDirection)
        {
            //.Log("turn stop");
            _bird.StopTurn();
            return;
        }

        if (transform.position.x < _point.transform.position.x && _bird.Velocity.x <= 0)
        {
            //Debug.Log("turn right");
            _bird.TurnRight();
            _timeSinceMove = 0;
        }

        if (transform.position.x > _point.transform.position.x && _bird.Velocity.x >= 0)
        {
            //Debug.Log("turn left");
            _bird.TurnLeft();
            _timeSinceMove = 0;
        }
    }
}

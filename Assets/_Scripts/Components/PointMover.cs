using UnityEngine;

public class PointMover : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    [SerializeField] private Jumper _bird;
    [SerializeField] private float _reactionTime;
    [SerializeField] private float _maxDirection = 0.05f;

    [SerializeField] private float _minTime, _maxTime;

    private Transform _currentPoint;

    private float _timeSinceMove;
    private float _timeSinceChangePoint;

    private float _currentTime;

    public void FixedMove()
    {
        _timeSinceMove += Time.deltaTime;
        _timeSinceChangePoint += Time.deltaTime;

        if (_timeSinceChangePoint >= _currentTime)
            ChangeMovePoint();

        if (_reactionTime < _timeSinceMove)
            Move();
    }

    private void ChangeMovePoint()
    {
        _timeSinceChangePoint = 0;
        _currentTime = Random.Range(_minTime, _maxTime);

        int index = Random.Range(0, _points.Length);
        _currentPoint = _points[index];
    }

    private void Move()
    {
        if (transform.position.y < _currentPoint.transform.position.y)
        {
            _bird.Jump();
            _timeSinceMove = 0;
        }

        var direction = _currentPoint.transform.position - _bird.transform.position;
        if (direction.magnitude <= _maxDirection)
        {
            //.Log("turn stop");
            _bird.StopTurn();
            return;
        }

        if (transform.position.x < _currentPoint.transform.position.x && _bird.Velocity.x <= 0)
        {
            //Debug.Log("turn right");
            _bird.TurnRight();
            _timeSinceMove = 0;
        }

        if (transform.position.x > _currentPoint.transform.position.x && _bird.Velocity.x >= 0)
        {
            //Debug.Log("turn left");
            _bird.TurnLeft();
            _timeSinceMove = 0;
        }
    }
}

using UnityEngine;

public class Mover
{
    private float _speed;

    private Rigidbody _rigidbody;

    public Mover(float speed, Rigidbody rigidbody)
    {
        _speed = speed;
        _rigidbody = rigidbody;
    }

    public void Move(Vector3 input)
    {
        Vector3 direction = input * _speed;
        Vector3 resetDirection = new Vector3(0, _rigidbody.velocity.y, 0);

        if (direction == Vector3.zero)
            _rigidbody.velocity = resetDirection;
        else
            _rigidbody.AddForce(direction);
    }
}

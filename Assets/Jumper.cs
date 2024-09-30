using UnityEngine;

public class Jumper
{
    private float _jumpForce;

    private Rigidbody _rigidbody;

    public Jumper(float jump, Rigidbody rigidbody)
    {
        _jumpForce = jump;
        _rigidbody = rigidbody;
    }

    public void Jump()
    {
        _rigidbody.AddForce(_jumpForce * Vector3.up, ForceMode.Impulse);
    }
}

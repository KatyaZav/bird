using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Jumper _currentJumper;
    private Mover _currentMover;

    private void Start()
    {
        _currentJumper = new Jumper(_jumpForce, _rigidbody);
        _currentMover = new Mover(_speed, _rigidbody);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _currentJumper.Jump();
    }

    void FixedUpdate()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 input = new Vector3(xInput, 0, zInput);
        _currentMover.Move(input);
    }
}

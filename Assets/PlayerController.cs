using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    private Jumper _currentJumper;
    private Mover _currentMover;

    private void Start()
    {
        _currentJumper = new Jumper(_jumpForce, _rigidbody);
        _currentMover = new Mover(_speed, _rigidbody);
    }

    // Update is called once per frame

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

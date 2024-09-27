using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;

    [SerializeField] float _speed;
    [SerializeField] float _jumpForce;

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _rigidbody.AddForce(_jumpForce * Vector3.up, ForceMode.Impulse);        
    }

    void FixedUpdate()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 direction  = new Vector3(xInput * _speed, 0, zInput * _speed);
        Vector3 resetDirection = new Vector3(0, _rigidbody.velocity.y, 0);

        if (direction == Vector3.zero)
            _rigidbody.velocity = resetDirection;
        else
            _rigidbody.AddForce(direction);
    }
}

using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;

    // Update is called once per frame
    void FixedUpdate()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float zInput = Input.GetAxisRaw("Vertical");

        Vector3 direction  = new Vector3(xInput, 0, zInput);

        if (direction == Vector3.zero)
            _rigidbody.velocity = Vector3.zero;
        else
            _rigidbody.AddForce(direction);
    }
}

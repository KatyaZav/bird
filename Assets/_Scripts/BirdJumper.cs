using UnityEngine;

public class BirdJumper : MonoBehaviour
{
    private const string FlyTriggerName = "fly";

    [Header("Settings")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;

    [SerializeField] private Vector2 _upperForce;
    [SerializeField] private Vector2 _leftForce;
    [SerializeField] private Vector2 _rightForce;

    [SerializeField] private GameObject _birdArt;

    public virtual void Jump()
    {
        MoveWithResetVelocity(_upperForce);
    }

    public void Swipe()
    {
        if (_rigidbody.velocity.x > 0)
            MoveWithResetVelocity(_leftForce);
        else
            MoveWithResetVelocity(_rightForce);

        SwipeSide();
    }

    public void StopMove()
    {
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector2.zero;
    }

    public void StartMove()
    {
        _rigidbody.isKinematic = false;

        transform.position = Vector2.zero;
        _rigidbody.velocity = Vector2.zero;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        StopMove();
        gameObject.SetActive(false);
    }

    private void OnValidate()
    {
        _rigidbody ??= GetComponent<Rigidbody2D>();
        _animator ??= GetComponent<Animator>();
    }
    
    private void SwipeSide()
    {
        if (_rigidbody.velocity.x > 0 && _birdArt.transform.localScale.x > 0 
            ||
            _rigidbody.velocity.x < 0 && _birdArt.transform.localScale.x < 0)
        {
            _birdArt.transform.localScale = new Vector3
                (_birdArt.transform.localScale.x * -1,1,1);
        }
    }   

    private void MoveWithResetVelocity(Vector2 moveDirection)
    {
        Vector2 resetVelocity = new Vector2(moveDirection.x == 0? _rigidbody.velocity.x : 0,
                                             moveDirection.y == 0? _rigidbody.velocity.y : 0);

        _rigidbody.velocity = resetVelocity;
        Move(moveDirection);
    }

    private void Move(Vector2 moveDirection)
    {
        _rigidbody.AddForce(moveDirection, ForceMode2D.Impulse);
        _animator.SetTrigger(FlyTriggerName);
    }
}

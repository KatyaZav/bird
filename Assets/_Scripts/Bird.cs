using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Vector2 _upperForce;
    [SerializeField] private Vector2 _leftForce;
    [SerializeField] private Vector2 _rightForce;

    private bool _isLive;
    
    public int Points {  get; private set; }
    
    public void Win()
    {
        _isLive = false;
        _rb.isKinematic = true;
        _rb.velocity = Vector2.zero;
    }

    public void Reset()
    {
        _isLive = true;  
        _rb.isKinematic = false;

        transform.position = Vector2.zero;
        _rb.velocity = Vector2.zero;

        gameObject.SetActive(true);

        Points = 0;
    }

    public void MakeDead()
    {
        Debug.Log("Bird is dead. Points: " + Points);

        _isLive = false;
        _rb.isKinematic = true;

        gameObject.SetActive(false);
    }

    private void Update()
    {
        int topJump = 1;
        int sideJump = 3;

        if (_isLive == false)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddPoint(topJump);
            MoveWithResetVelocity(_upperForce);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AddPoint(sideJump);
            MoveWithResetVelocity(_rightForce);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AddPoint(sideJump);
            MoveWithResetVelocity(_leftForce);
        }
    }

    private void MoveWithResetVelocity(Vector2 moveDirection)
    {
        Vector2 resetVelocity = new Vector2(moveDirection.x == 0? _rb.velocity.x : 0,
                                             moveDirection.y == 0? _rb.velocity.y : 0);

        _rb.velocity = resetVelocity;
        Move(moveDirection);
    }

    private void Move(Vector2 moveDirection)
    {
        _rb.AddForce(moveDirection, ForceMode2D.Impulse);
    }

    private void AddPoint(int point)
    {
        Points += point;
    }

    private void OnValidate()
    {
      _rb = GetComponent<Rigidbody2D>();
    }
}

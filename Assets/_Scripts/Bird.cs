using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private const string FlyTriggerName = "fly";

    [Header("Settings")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;

    [SerializeField] private Vector2 _upperForce;
    [SerializeField] private Vector2 _leftForce;
    [SerializeField] private Vector2 _rightForce;

    [SerializeField] private GameObject _birdArt;

    [Space(5)]
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _scaleStep;

    [Space(10), Header("Particles")]
    [SerializeField] private GameObject _deadParticle;

    [Space(10) ,Header("Points")]
    [SerializeField] private int _topJump = 1;
    [SerializeField] private int _sideJump = 3;

    private bool _isLive;
    
    public int Points {  get; private set; }
    
    public void Stop()
    {
        _isLive = false;
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector2.zero;
    }

    public void Reset()
    {
        _isLive = true;  
        _rigidbody.isKinematic = false;

        transform.position = Vector2.zero;
        _rigidbody.velocity = Vector2.zero;

        gameObject.SetActive(true);

        Points = 0;
    }

    public void MakeDead()
    {
        Debug.Log("Bird is dead. Points: " + Points);

        Instantiate(_deadParticle, transform.position, Quaternion.identity);

        Stop();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_isLive == false)
            return;
     
        DownScale();
        SwipeSide();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddPoint(_topJump);
            MoveWithResetVelocity(_upperForce);
            UpScale();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AddPoint(_sideJump);
            MoveWithResetVelocity(_rightForce);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AddPoint(_sideJump);
            MoveWithResetVelocity(_leftForce);
        }
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

    private void DownScale()
    {
        transform.localScale -= Vector3.one * _scaleStep * Time.deltaTime;

        if (transform.localScale.z < _minScale)
            transform.localScale = Vector3.one * _minScale;
    }

    private void UpScale()
    {
        transform.localScale += Vector3.one * _scaleStep;
        
        if (transform.localScale.z > _maxScale)
            transform.localScale = Vector3.one * _maxScale;
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

    private void AddPoint(int point)
    {
        Points += point;
    }

}

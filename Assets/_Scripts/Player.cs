using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Jumper _player;

    [Space(5)]
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _scaleStep;

    [Space(10), Header("Particles")]
    [SerializeField] private GameObject _deadParticle;

    public bool IsLive {get; private set;}

    public Jumper PlayerJumper  => _player; 

    private void Awake()
    {
        IsLive = true;
    }

    public void StartMove()
    {
        _player.StartMove();
    }

    public void Deactivate()
    {
        Instantiate(_deadParticle, transform.position, Quaternion.identity);
        _player.Deactivate();
    }
    public void Jump()
    {
        _player.Jump();
        UpScale();
    }

    private void Update()
    {
        DownScale();
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
}

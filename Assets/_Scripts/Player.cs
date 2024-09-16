using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BirdJumper
{
    [SerializeField] private Transform _npcBird;

    [Space(5)]
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _scaleStep;
    [SerializeField] private float _loseDistance;

    [Space(10), Header("Particles")]
    [SerializeField] private GameObject _deadParticle;

    private bool _isLive = true;

    public override void Deactivate()
    {
        Instantiate(_deadParticle, transform.position, Quaternion.identity);
        base.Deactivate();
    }
    public override void Jump()
    {
        base.Jump();
        UpScale();
    }

    private void Update()
    {
        if (_isLive == false)
            return;

        DownScale();
                
        if ((transform.position - _npcBird.position).magnitude > _loseDistance)
        {
            _isLive = false;
            Deactivate();
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
}

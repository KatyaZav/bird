using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private Transform _topBorder, _bottomBorder, _leftBorder, _rightBorder;
    [SerializeField] private int _winPoints;

    bool _isRunning;

    private void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        _isRunning = true;
        _bird.Reset();
    }

    private void Update()
    {
        if (_isRunning == false)
            return;

        if (IsInBorder(_bird.transform) == false)
        {
            _bird.MakeDead();
            _isRunning = false;
        }

        if (_bird.Points >= _winPoints)
        {
            _isRunning = false;
            _bird.Win();
        }
    }

    private bool IsInBorder(Transform obj)
    {
        return (obj.position.x > _leftBorder.position.x) 
            && (obj.position.x < _rightBorder.position.x)
            && (obj.position.y < _topBorder.position.y)
            && (obj.position.y > _bottomBorder.position.y);
    }

    private void OnValidate()
    {
        _bird ??=FindAnyObjectByType<Bird>();
    }
}

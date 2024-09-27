using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CollectableItem[] _items;
    [SerializeField] int _loseTime;

    private int _needToCollect;
    private bool _isWorking;

    private int _currentTime;
    private float _timer;

    private int _second = 1;

    // Start is called before the first frame update
    private void Start()
    {
        foreach (var item in _items)
        {
            item.Collected += Collect;
        }

        _needToCollect = _items.Length;
        _currentTime = _loseTime;

        _isWorking = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_isWorking == false)
            return;

        _timer += Time.deltaTime;

        if (_timer > _second)
        {
            _timer = 0;
            _currentTime -= _second;
            
            Debug.Log(_currentTime);
        
            if (_currentTime < 0)
            {
                Lose();
            }
        }
    }

    private void Collect(CollectableItem item)
    {
        item.Collected -= Collect;        
        _needToCollect--;
        Debug.Log($"Collected puncake. Need to collect {_needToCollect} more");

        if (_needToCollect == 0)
        {
            Win();
        }
    }

    private void Win()
    {
        _isWorking = false;
        Debug.Log("Win");
    }

    private void Lose()
    {
        _isWorking = false;
        Debug.Log("Lose");
    }
}

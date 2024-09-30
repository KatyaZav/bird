using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private CollectableItem[] _items;
    [SerializeField] private int _loseTime;

    private int _needToCollect;
    private bool _isWorking;

    private Timer _timer;
    
    private void Start()
    {
        foreach (var item in _items)
        {
            item.Collected += Collect;
        }

        _needToCollect = _items.Length;

        _timer = new Timer(_loseTime, 1);
        _timer.TimeEnded += Lose;

        _isWorking = true;
    }

    private void Update()
    {
        if (_isWorking == false)
            return;

        _timer.Update();
    }

    private void OnDisable()
    {
        _timer.TimeEnded -= Lose;

        foreach (var item in _items)
        {
            item.Collected -= Collect;
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

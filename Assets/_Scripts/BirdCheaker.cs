using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BirdCheaker : MonoBehaviour
{
    [SerializeField] private Transform _npcBird;
    [SerializeField] private Player _bird;
    [SerializeField] private Transform _topBorder, _bottomBorder, _leftBorder, _rightBorder;
    [SerializeField] private int _pointsToWin;
    [SerializeField] private Text _timerText;
    [SerializeField] private int _needTime;

    [SerializeField] private float _loseDistance;

    bool _isRunning;

    private void Start()
    {
        _timerText.text = "Start";

        //ResetGame();
        StartCoroutine(Timer());
    }

    public void ResetGame()
    {
        _isRunning = true;
        _bird.StartMove();
    }

    private void Update()
    {
        if (_isRunning == false)
            return;

        if (IsInBorder(_bird.transform) == false)
        {
            _bird.Deactivate();
            _isRunning = false;
        }

        if ((_bird.transform.position - _npcBird.position).magnitude > _loseDistance)
        {
            _bird.Deactivate();
        }
    }

    private IEnumerator Timer()
    {        
        bool isError = false;

        while (_needTime > 0)
        {
            if (_bird.IsLive == false)
            {
                isError = true;
                break;
            }

            _needTime--;
            _timerText.text = _needTime.ToString();
            yield return new WaitForSeconds(1);
        }

        if (isError)
            _timerText.text = "Lose";
        else
            _timerText.text = "Win!";
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
        _bird ??=FindAnyObjectByType<Player>();
    }
}

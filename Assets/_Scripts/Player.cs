using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ScaleChanger _scaleChanger;
    [SerializeField] private Jumper _jumper;

    [Space(10), Header("Particles")]
    [SerializeField] private GameObject _deadParticle;
    
    public bool IsLive {get; private set;}

    public Jumper PlayerJumper  => _jumper; 

    public void StartMove()
    {
        _jumper.StartMove();
    }
    public void Deactivate()
    {
        Instantiate(_deadParticle, transform.position, Quaternion.identity);
        _jumper.Deactivate();
    }
    public void Jump()
    {
        _jumper.Jump();
        _scaleChanger.UpScale();
    }
    public void TryUseItem()
    {
        //if ()
    }

    private void Awake()
    {
        IsLive = true;
    }

    private void Update()
    {
        _scaleChanger.DownScale();
    }
}

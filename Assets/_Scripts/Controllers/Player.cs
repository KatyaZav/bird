using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private ScaleChanger _scaleChanger;
    [SerializeField] private Jumper _jumper;
    [SerializeField] private ItemCollector _itemCollecter;
    [SerializeField] private Health _health;

    [Space(10), Header("Particles")]
    [SerializeField] private GameObject _deadParticle;

    private Inventory _inventory;
    
    public bool IsLive {get; private set;}

    public Jumper PlayerJumper  => _jumper; 
    public Inventory Inventory => _inventory;

    public void AddSpeed(float _coefficient)
    {
        _jumper.AddSpeed(_coefficient);
    }

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

    private void Awake()
    {
        IsLive = true;

        _itemCollecter.Init();
    }

    private void Update()
    {
        _scaleChanger.DownScale();
    }
}

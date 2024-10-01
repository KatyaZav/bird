using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    [SerializeField] ParticleSystem _collectEffect;
    [SerializeField] ParticleSystem _useEffect;

    private bool _isCollected = false;

    public virtual void Use(GameObject owner)
    {
        Debug.Log($"����������� ������� {gameObject.name}");

        Instantiate(_useEffect, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }

    public virtual void Get() 
    {
        if (_isCollected)
        { 
            Debug.Log($"������ {gameObject.name}  ��� ������");
            return;
        }    

        _isCollected = true;
        Debug.Log($"������ ������� {gameObject.name}");

        Instantiate(_collectEffect, transform.position, Quaternion.identity, null);
    }
}

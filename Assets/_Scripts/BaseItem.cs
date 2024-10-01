using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    [SerializeField] ParticleSystem _collectEffect;
    [SerializeField] ParticleSystem _useEffect;

    private bool _isCollected = false;

    public virtual void Use(GameObject owner)
    {
        Debug.Log($"Использован элемент {gameObject.name}");

        Instantiate(_useEffect, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }

    public virtual void Get() 
    {
        if (_isCollected)
        { 
            Debug.Log($"Объект {gameObject.name}  уже собран");
            return;
        }    

        _isCollected = true;
        Debug.Log($"Собран элемент {gameObject.name}");

        Instantiate(_collectEffect, transform.position, Quaternion.identity, null);
    }
}

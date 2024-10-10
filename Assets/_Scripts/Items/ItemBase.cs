using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] ParticleSystem _collectEffect;
    [SerializeField] ParticleSystem _useEffect;

    private bool _isCollected = false;

    public virtual bool CanPick(GameObject owner)
    {
        return owner.GetComponent<ItemCollector>() != null;
    } 

    public virtual void Use(GameObject owner)
    {
        if (_isCollected == false)
        {
            Debug.LogError("Предмет не подобран, поэтому не может быть использован!");
            return;
        }

        Debug.Log($"Использован элемент {gameObject.name}");

        Instantiate(_useEffect, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }

    public virtual void OnCollect() 
    {
        if (_isCollected)
        { 
            Debug.LogError($"Объект {gameObject.name}  уже собран");
            return;
        }    

        _isCollected = true;
        Debug.Log($"Собран элемент {gameObject.name}");

        Instantiate(_collectEffect, transform.position, Quaternion.identity, null);
    }
}

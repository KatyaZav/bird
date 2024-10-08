using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    [SerializeField] ParticleSystem _collectEffect;
    [SerializeField] ParticleSystem _useEffect;

    private bool _isCollected = false;

    public virtual bool CanPick(GameObject owner)
    {
        return owner.GetComponent<ItemCollecter>() != null;
    } 

    public virtual void Use(GameObject owner)
    {
        if (_isCollected)
        {
            Debug.LogError("������� �� ��������, ������� �� ����� ���� �����������!");
            return;
        }

        Debug.Log($"����������� ������� {gameObject.name}");

        Instantiate(_useEffect, transform.position, Quaternion.identity, null);
        Destroy(gameObject);
    }

    public virtual void OnCollect() 
    {
        if (_isCollected)
        { 
            Debug.LogError($"������ {gameObject.name}  ��� ������");
            return;
        }    

        _isCollected = true;
        Debug.Log($"������ ������� {gameObject.name}");

        Instantiate(_collectEffect, transform.position, Quaternion.identity, null);
    }
}

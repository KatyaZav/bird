using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    [SerializeField] ParticleSystem _collectEffect;
    [SerializeField] ParticleSystem _useEffect;

    private bool _isCollected = false;

    public virtual void Use()
    {
        Debug.Log($"����������� ������� {gameObject.name}");

        Instantiate(_useEffect, transform, true);
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

        Instantiate(_collectEffect, transform, true);
    }
}

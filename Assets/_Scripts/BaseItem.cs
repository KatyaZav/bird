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
        Debug.Log($"Использован элемент {gameObject.name}");

        Instantiate(_useEffect, transform, true);
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

        Instantiate(_collectEffect, transform, true);
    }
}

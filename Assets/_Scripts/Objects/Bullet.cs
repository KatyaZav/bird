using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] float _force;
    

    public void Launch(Vector2 direction)
    {
        _rigidbody.AddForce(_force * direction, ForceMode2D.Impulse);
    }
}

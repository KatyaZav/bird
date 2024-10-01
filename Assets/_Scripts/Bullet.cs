using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Vector2 _velocity;
    

    public void Launch(float coefficient)
    {
        _rigidbody.AddForce(_velocity * coefficient, ForceMode2D.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChanger : MonoBehaviour
{
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;
    [SerializeField] private float _scaleStep;

    public void DownScale()
    {
        transform.localScale -= Vector3.one * _scaleStep * Time.deltaTime;

        if (transform.localScale.z < _minScale)
            transform.localScale = Vector3.one * _minScale;
    }

    public void UpScale()
    {
        transform.localScale += Vector3.one * _scaleStep;

        if (transform.localScale.z > _maxScale)
            transform.localScale = Vector3.one * _maxScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycleBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _dayLength;

    [SerializeField]
    private float _rotationSpeed;

    void Update()
    {
        _rotationSpeed = Time.deltaTime / _dayLength;
        transform.Rotate(0, _rotationSpeed, 0);
    }
}

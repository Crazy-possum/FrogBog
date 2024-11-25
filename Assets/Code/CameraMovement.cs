using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _speed;
    private Vector2 _startPosition;

    void Start()
    {
        _startPosition = _cameraTransform.position;
    }

    void FixedUpdate()
    {
        _cameraTransform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}

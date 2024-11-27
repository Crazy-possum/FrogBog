using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private Rigidbody2D _rbCamera;
    [SerializeField] private float _speed;
    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = _cameraTransform.position;
    }

    void FixedUpdate()
    {
        _rbCamera.velocity = new Vector2(_speed, _rbCamera.velocity.y);
    }

    public void ToStartPosition()
    {
        _cameraTransform.position = _startPosition;
    }
}


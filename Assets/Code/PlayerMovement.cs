using Extention;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _jumpForce = 700f;
    [SerializeField] private float _timerDuration = 2.5f;
    [SerializeField] private GameObject _playerCamera;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rbody2d;
    private Timer _timer;
    private bool _jump;
    private float _startCameraPositionY;
    private int _currentjumpCounter;

    void Start()
    {
        _rbody2d = GetComponent<Rigidbody2D>();
        _startCameraPositionY = _playerCamera.transform.position.y;
        _timer = new Timer(_timerDuration, false);
    }

    private void Update()
    {
        FixCameraY();

        if (Input.GetKeyDown(KeyCode.Space))
        {
           _jump = true;
        }
    }

    void FixedUpdate()
    {
        Movement();
        Jump(); 
    }

    private void FixCameraY()
    {
        _playerCamera.transform.position = 
            new Vector3(_playerCamera.transform.position.x, _startCameraPositionY, -10);
    }

    private void Jump()
    {
        if (_jump & _currentjumpCounter < 3)
        {
            _rbody2d.velocity = new Vector2(_rbody2d.velocity.x,0);
            _rbody2d.AddForce(new Vector2(0,_jumpForce));
            _jump = false;

            if (_currentjumpCounter == 0)
            {
                _timer = new Timer(_timerDuration);
            }

            _currentjumpCounter++;
        }
        if (_timer.Wait())
        {
            _currentjumpCounter = 0;
        }
    }

    void Movement()
    {
        if (_groundChecker.IsGrounded == false)
        {
            _rbody2d.velocity = new Vector2(_speed, _rbody2d.velocity.y);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private CameraTrigger _cameraTrigger;
    [SerializeField] private PlayerTrigger _playerTrigger;
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _player;

    void Start()
    {
        _cameraTrigger.OnCameraEnterTrigger += ChangeToSecondStage;
        _playerTrigger.OnPlayerEnterTrigger += ChangeToThirdStage;
    }

    private void OnDestroy()
    {
        _cameraTrigger.OnCameraEnterTrigger -= ChangeToSecondStage;
        _playerTrigger.OnPlayerEnterTrigger -= ChangeToThirdStage;
    }

    private void ChangeToSecondStage()
    {
        _camera.SetActive(false);
        _player.SetActive(true);
    }

    private void ChangeToThirdStage()
    {
        _cameraMovement.ToStartPosition();
        _player.SetActive(false);
        _camera.SetActive(true);
    }
}


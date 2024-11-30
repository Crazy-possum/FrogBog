using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    private static StageController _instance;
    [SerializeField] private CameraTrigger _cameraTrigger;
    [SerializeField] private PlayerTrigger _playerTrigger;
    [SerializeField] private CameraMovement _cameraMovement;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _player;
    private Action<int> _onChangeStage;

    public static StageController Instance { get => _instance; set => _instance = value; }
    public Action<int> OnChangeStage { get => _onChangeStage; set => _onChangeStage = value; }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if(_instance == this)
        {
            Destroy(gameObject);
        }
    }

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
        OnChangeStage?.Invoke(2);

        _camera.SetActive(false);
        _player.SetActive(true);
    }

    private void ChangeToThirdStage()
    {
        OnChangeStage?.Invoke(3);

        _cameraMovement.ToStartPosition();
        _player.SetActive(false);
        _camera.SetActive(true);
    }
}
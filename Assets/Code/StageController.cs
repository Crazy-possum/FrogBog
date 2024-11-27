using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField] private CameraTrigger _trigger;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _player;

    void Start()
    {
        _trigger.OnCameraEnterTrigger += ChangeToSecondStage;
    }

    private void OnDestroy()
    {
        _trigger.OnCameraEnterTrigger -= ChangeToSecondStage;
    }

    private void ChangeToSecondStage()
    {
        _camera.SetActive(false);
        _player.SetActive(true);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSercher : MonoBehaviour
{
    [SerializeField] private Transform _topSpawnTransform;
    [SerializeField] private Transform _centerSpawnTransform;
    [SerializeField] private Transform _bottomSpawnTransform;
    [SerializeField] private CameraTrigger _cameraTrigger;
    private Action<Vector2> _onSpawnAction;

    public Action<Vector2> OnSpawnAction { get => _onSpawnAction; set => _onSpawnAction = value; }

    private void Start()
    {
        _cameraTrigger.OnCameraEnterTrigger += SpawnAction;
    }

    private void OnDestroy()
    {
        _cameraTrigger.OnCameraEnterTrigger -= SpawnAction;
    }

    private Vector2 GetSpawnPosition()
    {
        Vector2 position = Vector2.zero;

        System.Random random = new System.Random();
        int transformIndex = random.Next(0, 3);

        switch(transformIndex)
        {
            case 0:
                position = _topSpawnTransform.position;
                break;
            case 1:
                position = _centerSpawnTransform.position;
                break;
            case 2:
                position = _bottomSpawnTransform.position;
                break;
            default:
                break;
        }

        return position;
    }

    private void SpawnAction()
    {
        OnSpawnAction?.Invoke(GetSpawnPosition());
    }
}
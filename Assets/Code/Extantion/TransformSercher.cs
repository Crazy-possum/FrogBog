using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformSercher : MonoBehaviour
{
    [SerializeField] private Transform _topSpawnTransform;
    [SerializeField] private Transform _centerSpawnTransform;
    [SerializeField] private Transform _bottomSpawnTransform;

    public Vector2 GetSpawnPosition()
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
}
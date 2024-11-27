using System;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    private Action _onCameraEnterTrigger;

    public Action OnCameraEnterTrigger { get => _onCameraEnterTrigger; set => _onCameraEnterTrigger = value; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MainCamera")
        {
            OnCameraEnterTrigger?.Invoke();
        }
    }
}

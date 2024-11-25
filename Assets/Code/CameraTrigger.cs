using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    private Action _onCameraEnterTrigger;

    public Action OnCameraEnterTrigger { get => _onCameraEnterTrigger; set => _onCameraEnterTrigger = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MainCamera")
        {
            OnCameraEnterTrigger.Invoke();
        }
        Debug.Log("rgr");
    }
}

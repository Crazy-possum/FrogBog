using System;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private Action _onPlayerEnterTrigger;

    public Action OnPlayerEnterTrigger { get => _onPlayerEnterTrigger; set => _onPlayerEnterTrigger = value; }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnPlayerEnterTrigger?.Invoke();
        }
    }
}
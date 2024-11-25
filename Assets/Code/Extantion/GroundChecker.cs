using System.Collections.Generic;
using UnityEngine;

internal class GroundChecker : MonoBehaviour 
{
    public bool IsGrounded;
    private List<GameObject> _floorObjects;

    private void Awake()
    {
        _floorObjects = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag != "Player")&(collision.gameObject.tag != "Enemy")) 
        {
            _floorObjects.Add(collision.gameObject);
            IsGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_floorObjects.Contains(collision.gameObject))
        {
            _floorObjects.Remove(collision.gameObject);
            if (_floorObjects.Count == 0)
            {
                IsGrounded = false;
            }
        }
    }
}
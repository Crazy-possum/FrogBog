using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
    private static EndGameController _instance;
    [SerializeField] private GameObject _mainPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _winPanel;

    public static EndGameController Instance { get => _instance; set => _instance = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1;
    }
    public void LoseGameAction()
    {
        Time.timeScale = 0;
        _mainPanel.SetActive(true);
        _losePanel.SetActive(true);
    }

    public void WinGameAction()
    {
        Time.timeScale = 0;
        _mainPanel.SetActive(true);
        _winPanel.SetActive(true);
    }
}

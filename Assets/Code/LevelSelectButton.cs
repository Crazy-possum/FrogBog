using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorButton : MonoBehaviour
    //Повесить на префаб кнопки и поменять на самой сцене индексы для разных кнопок
{
    public Button LevelSelectButton;
    public int Index;

    private void Awake()
    {
        LevelSelectButton.onClick.AddListener(LoadLevel);
    }

    private void OnDestroy()
    {
        LevelSelectButton.onClick.RemoveAllListeners();
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(Index);
    }
}
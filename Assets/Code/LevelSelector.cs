using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
    //Не забыть поправить ссылки на кнопки
{
    public Button Level1Button;
    public Button Level2Button;
    public Button Level3Button;
    public Button Level4Button;
    public Button Level5Button;
    public Button Level6Button;

    private void Awake()
    {
        Level1Button.onClick.AddListener(SelectLevel1);
        Level2Button.onClick.AddListener(SelectLevel2);
        Level3Button.onClick.AddListener(SelectLevel3);
        Level4Button.onClick.AddListener(SelectLevel4);
        Level5Button.onClick.AddListener(SelectLevel5);
        Level6Button.onClick.AddListener(SelectLevel6);
    }

    private void OnDestroy()
    {
        Level1Button.onClick.RemoveAllListeners();
        Level2Button.onClick.RemoveAllListeners();
        Level3Button.onClick.RemoveAllListeners();
        Level4Button.onClick.RemoveAllListeners();
        Level5Button.onClick.RemoveAllListeners();
        Level6Button.onClick.RemoveAllListeners();
    }

    private void SelectLevel1()
    {
        SceneManager.LoadScene(1);
    }

    private void SelectLevel2()
    {
        SceneManager.LoadScene(2);
    }

    private void SelectLevel3()
    {
        SceneManager.LoadScene(3);
    }

    private void SelectLevel4()
    {
        SceneManager.LoadScene(4);
    }

    private void SelectLevel5()
    {
        SceneManager.LoadScene(5);
    }

    private void SelectLevel6()
    {
        SceneManager.LoadScene(6);
    }
}
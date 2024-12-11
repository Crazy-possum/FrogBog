using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSaver : MonoBehaviour
{
    private static MusicSaver _instance;
    [SerializeField] private AudioSource _bgMusic;

    public static MusicSaver Instance { get => _instance;}

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;

        if (Instance == null)
        {
            _instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "3")
        {
            _bgMusic.mute = true;
        }
        else
        {
            _bgMusic.mute = false;
        }
    }

    private void Destroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

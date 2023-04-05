using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI startButton;
    private void Start()
    {
        if (SceneControl.CurrentBestSceneIndex > 1)
            startButton.text = "Продолжить";
    }
    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void Play()
    {
        SceneManager.LoadScene(SceneControl.CurrentBestSceneIndex);
    }

    public static void GoToLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

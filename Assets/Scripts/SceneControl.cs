using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public static int CurrentBestSceneIndex = 1;

    public static void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void UpdateMaxSceneIndex()
    {
        if (CurrentBestSceneIndex == SceneManager.GetActiveScene().buildIndex)
            CurrentBestSceneIndex++;
    }
    
}

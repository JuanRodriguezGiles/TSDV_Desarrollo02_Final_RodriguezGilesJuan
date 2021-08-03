using UnityEngine;
using UnityEngine.SceneManagement;
public class UiMainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        GameManager.Instance.LoadGameplayScene();
        SaveManager.Instance.Load();
    }
    public void LoadGameplayScene()
    {
      GameManager.Instance.LoadGameplayScene();
    }
    public void LoadHighScoreScene()
    {
        GameManager.Instance.LoadHighScoreScene();
    }
    public void LoadCreditsScene()
    {
       GameManager.Instance.LoadCreditsScene();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
public class UiMainMenu : MonoBehaviour
{
    public void LoadGameplayScene()
    {
      GameManager.Instance.LoadGameplayScene();
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
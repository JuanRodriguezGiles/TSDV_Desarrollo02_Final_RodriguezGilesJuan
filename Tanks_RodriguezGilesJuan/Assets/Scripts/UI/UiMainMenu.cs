using UnityEngine;
using UnityEngine.SceneManagement;
public class UiMainMenu : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
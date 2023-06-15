using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Start()
    {
        // Desbloqueia o cursor do mouse
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
        // Carrega a cena do jogo principal
        SceneManager.LoadScene("BaseGame");
    }

    public void OpenHelpMenu()
    {
        // Carrega a cena do menu de ajuda
        SceneManager.LoadScene("HelpScene");
    }

    public void GoToMainMenu()
    {
        // Carrega a cena do menu de ajuda
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        // Sai do jogo (funciona apenas em builds do jogo)
        Application.Quit();
    }
}

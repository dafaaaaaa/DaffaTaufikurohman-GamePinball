using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button mainMenu;
    public Button credit;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        mainMenu.onClick.AddListener(MainMenu);
        credit.onClick.AddListener(Credit);
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credit");
    }
    
    public void MainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Pinball Level 2");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}

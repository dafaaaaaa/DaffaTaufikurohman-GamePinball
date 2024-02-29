using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOverUIController : MonoBehaviour
{
	// reference untuk button
  public Button mainMenuButton;

  private void Start()
  {
		// setup event saat button di klik
    mainMenuButton.onClick.AddListener(MainMenu);
  }

  public void MainMenu()
  {
		// kembali ke main menu
    SceneManager.LoadScene("MainMenu");
  }
}
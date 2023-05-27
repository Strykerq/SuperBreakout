using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void StartGame()
   {
       SceneManager.LoadScene(1);
       Time.timeScale = 1f;
       SliderController.isMainMenu = false;
   }

  public void QuitGame()
  {
      Application.Quit();
      Debug.Log("QUIT");
  }
}
